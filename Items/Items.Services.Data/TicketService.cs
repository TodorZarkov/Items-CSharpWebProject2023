﻿namespace Items.Services.Data
{
    using Items.Data;
    using Items.Services.Data.Interfaces;
    using Items.Services.Data.Models.Ticket;
    using static Items.Common.TicketConstants;
    using static Items.Common.FormatConstants.DateAndTime;
    using Items.Data.Models;

    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Items.Services.Data.Models.File;
    using System.Net.Mime;
    using static Items.Common.EntityValidationConstants;
    using Items.Services.Common.Interfaces;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.AspNetCore.Identity;
    using Items.Common;

    public class TicketService : ITicketService
    {
        private readonly ItemsDbContext dbContext;
        private readonly IFileService fileService;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly UserManager<ApplicationUser> userManager;

        public TicketService(
            ItemsDbContext dbContext,
            IFileService fileService,
            IDateTimeProvider dateTimeProvider,
            UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.fileService = fileService;
            this.dateTimeProvider = dateTimeProvider;
            this.userManager = userManager;
        }

        public async Task<Guid> AddAsync(Guid userId, TicketFormServiceModel model)
        {
            Items.Data.Models.TicketStatus openStatus = await dbContext.TicketStatuses
                .FirstAsync(s => s.Name == Statuses.OPEN);

            Items.Data.Models.Ticket ticket = new Items.Data.Models.Ticket
            {
                AuthorId = userId,
                Description = model.Description,
                Title = model.Title,
                TypeId = model.TypeId,
                TicketStatus = openStatus,
                Created = dateTimeProvider.GetCurrentDateTime(),
                Modified = dateTimeProvider.GetCurrentDateTime()
            };

            if (model.SnapShot != null)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    await model.SnapShot.CopyToAsync(stream);
                    var fileModel = new FileServiceModel
                    {
                        Bytes = stream.ToArray(),
                        MimeType = MediaTypeNames.Image.Jpeg
                    };
                    ticket.SnapshotId = await fileService.AddAsync(fileModel);
                }
            }

            await dbContext.Tickets.AddAsync(ticket);

            await dbContext.SaveChangesAsync();
            await fileService.SaveChangesAsync();
            return ticket.Id;
        }

        public async Task AssignAsync(
            Guid ticketId, 
            Guid userId, 
            TicketUpdateServiceModel model)
        {
            var ticket = await dbContext.Tickets
                .Include(t => t.TicketStatus)
                .FirstOrDefaultAsync(t => t.Id == ticketId)
                ?? throw new ArgumentException("No ticket with this id");

            var assignStatus = await dbContext.TicketStatuses
                .FirstAsync(ts => ts.Name == Statuses.ASSIGN);

            ticket.AssigneeId = model.AssigneeId;
            ticket.AssignerId = userId;
            ticket.TicketStatus = assignStatus;
            ticket.Modified = dateTimeProvider.GetCurrentDateTime();

            await dbContext.SaveChangesAsync();
        }

        public async Task AssignToSelfAsync(Guid ticketId,Guid userId)
        {
            var ticket = await dbContext.Tickets
                .Include(t => t.TicketStatus)
                .FirstOrDefaultAsync(t => t.Id == ticketId)
                ?? throw new ArgumentException("No ticket with this id");
            var assignStatus = await dbContext.TicketStatuses
                .FirstAsync(ts => ts.Name == Statuses.ASSIGN);

            ticket.AssigneeId = userId;
            ticket.AssignerId = userId;
            ticket.TicketStatus = assignStatus;
            ticket.Modified = dateTimeProvider.GetCurrentDateTime();

            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> CanDeleteAsync(Guid? userId, Guid ticketId)
        {
            bool result = await dbContext.Tickets
                .AnyAsync(t => t.Id == ticketId
                                && t.AuthorId == userId
                                && t.AssigneeId == null
                                && t.AssignerId == null
                                && t.WithSameProblem.Count == 0);

            return result;
        }

        public async Task ChangeSeverityStatusTypeAsync( Guid ticketId, TicketUpdateServiceModel model)
        {
            var ticket = await dbContext.Tickets
               .FindAsync(ticketId)
               ?? throw new ArgumentException("No ticket with this id");
            
            if(model.TypeId != null) { ticket.TypeId = (int)model.TypeId; }
            if(model.Severity != null) { ticket.Severity = (int)model.Severity; }
            if(model.StatusId != null) { ticket.StatusId = (int)model.StatusId; }
            ticket.Modified = dateTimeProvider.GetCurrentDateTime();

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid ticketId)
        {
            var ticket = await dbContext.Tickets.FindAsync(ticketId)
                ?? throw new NullReferenceException("Ticket not found");

            var statusDelete = await dbContext.TicketStatuses
                .FirstOrDefaultAsync(ts => ts.Name == Statuses.DELETE) ??
                throw new NullReferenceException("Status Delete not found");

            var ticketsSubscribers = await dbContext.TicketsSubscribers
                .Where(ts => ts.TicketId == ticketId)
                .ToArrayAsync();
            if (!ticketsSubscribers.IsNullOrEmpty())
            {
                dbContext.TicketsSubscribers.RemoveRange(ticketsSubscribers);
            }

            ticket.TicketStatus = statusDelete;
            ticket.Modified = dateTimeProvider.GetCurrentDateTime();

            await dbContext.SaveChangesAsync();
        }

        public async Task EditAsUserAsync(Guid ticketId,
            TicketEditAsUserServiceModel model)
        {
            var ticket = await dbContext.Tickets
                .FindAsync(ticketId)
                ?? throw new ArgumentException("No ticket with this id!");
            ticket.Title = model.Title!;
            ticket.Description = model.Description;
            ticket.TypeId = (int)model.TypeId!;
            ticket.Modified = dateTimeProvider.GetCurrentDateTime();

            if (model.SnapShot != null)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    await model.SnapShot.CopyToAsync(stream);
                    var fileModel = new FileServiceModel
                    {
                        Bytes = stream.ToArray(),
                        MimeType = MediaTypeNames.Image.Jpeg
                    };
                    if (ticket.SnapshotId != null)
                    {
                        await fileService.ModifyAsync((Guid)ticket.SnapshotId, fileModel);
                    }
                    else
                    {
                        ticket.SnapshotId = await fileService.AddAsync(fileModel);
                    }
                }
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<AllTicketInfoServiceModel> GetAllAsync(TicketQueryModel? queryModel = null)
        {
            var query = dbContext.Tickets
                .AsNoTracking()
                .AsQueryable()
                .Where(t => t.TicketStatus.Name != Statuses.DELETE);

            if (queryModel is not null)
            {
                string? searchTerm = queryModel.SearchTerm;
                if (searchTerm is not null)
                {
                    query = query
                    .Where(
                        t => t.Title.ToUpper().Contains(searchTerm) ||
                            (t.Description != null && t.Description.ToUpper().Contains(searchTerm))
                    );
                }

                string[]? statusesToInclude = queryModel.IncludeStatuses;
                if (statusesToInclude != null && statusesToInclude.Length > 0)
                {
                    query = query
                        .Where(t => statusesToInclude.Contains(t.TicketStatus.Name));
                }

                string[]? typesToInclude = queryModel.IncludeTypes;
                if (typesToInclude != null && typesToInclude.Length > 0)
                {
                    query = query
                        .Where(t => typesToInclude.Contains(t.TicketType.Name));
                }
            }
            int totalCount = await query.CountAsync();


            int hitsPerPage = queryModel?.HitsPerPage ?? Query.HitsPerPage;
            int currentPage = queryModel?.CurrentPage ?? Query.CurrentPage;
            query = query
                .Skip((currentPage - 1) * hitsPerPage)
                .Take(hitsPerPage);

            AllTicketServiceModel[] tickets = await query
                .Select(t => new AllTicketServiceModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Type = t.TicketType.Name,
                    Status = t.TicketStatus.Name,
                    Created = t.Created.ToString(TicketDatetimeFormat),
                    Severity = t.Severity,
                    WithSameProblem = t.WithSameProblem
                        .Where(wp => wp.TicketId == t.Id)
                        .LongCount(),
                    SnapShot = null,
                    SnapshotId = t.SnapshotId
                })
                .ToArrayAsync();

            foreach (var ticket in tickets)
            {
                if (ticket.SnapshotId == null) continue;

                ticket.SnapShot = (await fileService.GetAsync((Guid)ticket.SnapshotId)).Bytes;
            }

            AllTicketInfoServiceModel result = new AllTicketInfoServiceModel
            {
                Tickets = tickets,
                TotalCount = totalCount
            };

            return result;

        }

        public async Task<TicketDetailsServiceModel> GetAsync(Guid ticketId, Guid? userId)
        {
            var ticket = await dbContext.Tickets
                .Include(t => t.TicketType)
                .Include(t => t.TicketStatus)
                .Include(t => t.Assignee)
                .Include(t => t.Assigner)
                .Include(t => t.Author)
                .Include(t => t.WithSameProblem)
                .Include(t => t.Subscribers)
                .FirstOrDefaultAsync(t => t.Id == ticketId &&
                            t.TicketStatus.Name != Statuses.DELETE) ??
                throw new ArgumentNullException(nameof(ticketId), "The ticket id doesn't match any Ticket.");


            TicketDetailsServiceModel ticketModel =
                new TicketDetailsServiceModel
                {
                    Title = ticket.Title,
                    Description = ticket.Description,
                    TicketType = ticket.TicketType.Name,
                    TicketStatus = ticket.TicketStatus.Name,
                    AssigneeId = ticket.AssigneeId,
                    AssigneeName = ticket.Assignee?.UserName,
                    AssignerId = ticket.AssignerId,
                    AssignerName = ticket.Assigner?.UserName,
                    AuthorId = ticket.AuthorId,
                    AuthorName = ticket.Author.UserName,
                    Created = ticket.Created.ToString(TicketDatetimeFormat),
                    Severity = ticket.Severity,
                    WithSameProblem = ticket.WithSameProblem
                        .Where(wp => wp.TicketId == ticket.Id)
                        .LongCount(),
                    SnapShot = null,
                    SnapshotId = ticket.SnapshotId,
                    Modified = ticket.Modified.ToString(TicketDatetimeFormat),
                    Subscribers = ticket.Subscribers
                        .Where(s => s.TicketId == ticket.Id)
                        .LongCount(),
                    Subscribed = userId != null && ticket.Subscribers
                            .Any(s => s.SubscriberId == userId && s.TicketId == ticket.Id),
                    IHaveSameProblem = userId != null && ticket.WithSameProblem
                            .Any(wp => wp.UserId == userId && wp.TicketId == ticket.Id)
                };

            if (ticket.SnapshotId != null)
            {
                FileServiceModel snapshot =
                    await fileService.GetAsync((Guid)ticket.SnapshotId);
                ticketModel.SnapShot = snapshot.Bytes;
            }


            return ticketModel;
        }

        public async Task<TicketUserState> GetStateAsync(Guid ticketId, Guid userId)
        {
            var ticket = await dbContext.Tickets
                .FindAsync(ticketId)
                ?? throw new ArgumentException("No ticket with this id");

            var anyWithSameProblem = await dbContext.SimilarTicketsUsers
                .AnyAsync(stu => stu.TicketId == ticketId);

            var user = await dbContext.Users
                .FindAsync(userId) 
                ?? throw new ArgumentException("No user with this id");
            var userRoles = await userManager.GetRolesAsync(user);

            var actualStatus = await dbContext.Tickets
                .Where(t => t.Id == ticketId)
                .Select(t => t.TicketStatus.Name)
                .FirstOrDefaultAsync();

            var isDeleted = actualStatus == Statuses.DELETE;
            var isClosed = actualStatus == Statuses.CLOSE;

            TicketUserState state = new TicketUserState
            {
                isTicketAssigned = ticket.AssigneeId != null && ticket.AssignerId != null,
                isAssignee = ticket.AssigneeId != null && ticket.AssigneeId == userId,
                isAssigner = ticket.AssignerId != null && ticket.AssignerId == userId,
                isCreator = ticket.AuthorId == userId,
                isUser = !userRoles.Any(),
                isAdmin = userRoles.Any() && userRoles.Contains(RoleConstants.Admin),
                isSuperAdmin = userRoles.Any() && userRoles.Contains(RoleConstants.SuperAdmin),
                anyWithSameProblem = anyWithSameProblem,
                isDeleted = isDeleted,
                isClosed = isClosed
            };

            return state;
        }

        public async Task<Guid> ToggleAsync(TicketUpdateServiceModel model, Guid ticketId, Guid userId)
        {
            if (model.ToggleSameProblem != null && (bool)model.ToggleSameProblem)
            {
                SimilarTicketUser? stu = await dbContext.SimilarTicketsUsers
                    .FindAsync(ticketId, userId);
                if (stu != null)
                {
                    dbContext.SimilarTicketsUsers.Remove(stu);
                }
                else
                {
                    stu = new SimilarTicketUser
                    {
                        TicketId = ticketId,
                        UserId = userId
                    };
                    await dbContext.SimilarTicketsUsers.AddAsync(stu);
                }
                await dbContext.SaveChangesAsync();
            }

            if (model.ToggleSubscribe != null && (bool)model.ToggleSubscribe)
            {
                TicketSubscriber? ts = await dbContext.TicketsSubscribers
                    .FindAsync(ticketId, userId);
                if (ts != null)
                {
                    dbContext.TicketsSubscribers.Remove(ts);
                }
                else
                {
                    ts = new TicketSubscriber
                    {
                        TicketId = ticketId,
                        SubscriberId = userId
                    };
                    await dbContext.TicketsSubscribers.AddAsync(ts);
                }
            }

            await dbContext.SaveChangesAsync();

            return ticketId;
        }
    }
}
