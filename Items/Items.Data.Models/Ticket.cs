﻿namespace Items.Data.Models
{
    using static Items.Common.EntityValidationConstants.Ticket;

	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

    public class Ticket
    {
        public Ticket()
        {
            WithSameProblem = new HashSet<SimilarTicketUser>();
            Subscribers = new HashSet<TicketSubscriber>();
        }


        [Key]
        public Guid Id { get; set; }


        [Required]
        [ForeignKey(nameof(TicketType))]
        public int TypeId { get; set; }
        [Required]
        public TicketType TicketType { get; set; } = null!;


        [Required]
        [MaxLength(TitleMax)]
        public string Title { get; set; } = null!;


        [MaxLength(DescriptionMax)]
        public string? Description { get; set; }


        public Guid? SnapshotId { get; set; }


        [Required]
        [ForeignKey(nameof(TicketStatus))]
        public int StatusId { get; set; }
        [Required]
        public TicketStatus TicketStatus { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }
        [Required]
        public ApplicationUser Author { get; set; } = null!;


        [ForeignKey(nameof(Assigner))]
        public Guid? AssignerId { get; set; }
        public ApplicationUser? Assigner { get; set; }


		[ForeignKey(nameof(Assignee))]
		public Guid? AssigneeId { get; set; }
		public ApplicationUser? Assignee { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public int Severity { get; set; }

        public ICollection<SimilarTicketUser> WithSameProblem { get; set; }

        public ICollection<TicketSubscriber> Subscribers { get; set; }
    }
}
