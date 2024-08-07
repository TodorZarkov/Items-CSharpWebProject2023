﻿namespace Items.Data
{

    using System.Reflection;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Items.Data.Models;
    using Items.Data.Seeders;

    public class ItemsDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private bool seed;

        public ItemsDbContext(DbContextOptions<ItemsDbContext> options, bool seed = true)
            : base(options)
        {
            this.seed = seed;
            if (!Database.IsRelational())
            {
                Database.EnsureCreated();
            }
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Contract> Contracts { get; set; } = null!;

        public DbSet<Currency> Currencies { get; set; } = null!;

        public DbSet<Document> Documents { get; set; } = null!;

        public DbSet<Item> Items { get; set; } = null!;

        public DbSet<ItemCategory> ItemsCategories { get; set; } = null!;

        public DbSet<ItemVisibility> ItemVisibilities { get; set; } = null!;

        public DbSet<Location> Locations { get; set; } = null!;

        public DbSet<LocationVisibility> LocationVisibilities { get; set; } = null!;

        public DbSet<Offer> Offers { get; set; } = null!;

        public DbSet<FileIdentifier> FileIdentifiers { get; set; } = null!;

        public DbSet<Place> Places { get; set; } = null!;

        public DbSet<Unit> Units { get; set; } = null!;

        public DbSet<Ticket> Tickets { get; set; } = null!;

        public DbSet<TicketStatus> TicketStatuses { get; set; } = null!;

        public DbSet<TicketType> TicketTypes { get; set; } = null!;

        public DbSet<TicketSubscriber> TicketsSubscribers { get; set; } = null!;

        public DbSet<SimilarTicketUser> SimilarTicketsUsers { get; set; } = null!;


        //to be deleted if using not db file service. it has no references apart from InDbFileService
        public DbSet<File> Files { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Assembly configAssembly = Assembly.GetAssembly(typeof(ItemsDbContext)) ??
                Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);


            if (seed)
            {
                builder.Seed();
            }

        }
    }
}