﻿namespace Items.Data.Configurations
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SimilarTicketUserEntityConfiguration
        : IEntityTypeConfiguration<SimilarTicketUser>
    {
        public void Configure(EntityTypeBuilder<SimilarTicketUser> builder)
        {
            builder.HasKey(stu => new { stu.TicketId, stu.UserId });

            builder.HasOne(stu => stu.Ticket)
                .WithMany(t => t.WithSameProblem)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(stu => stu.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
