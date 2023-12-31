﻿namespace Items.Data.Models
{
    using Items.Common.Enums;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class LocationVisibility
    {
        public LocationVisibility()
        {
            Id = Guid.NewGuid();
            Country = AccessModifier.Public;
            Town = AccessModifier.Public;

            GeoLocation = AccessModifier.Private;

            Name = AccessModifier.Private;
            Description = AccessModifier.Private;
            Border = AccessModifier.Private;
            Address = AccessModifier.Private;
        }

        [Key]
        public Guid Id { get; set; }

        public AccessModifier Name { get; set; }

        public AccessModifier Description { get; set; }

        public AccessModifier GeoLocation { get; set; }

        public AccessModifier Border { get; set; }

        public AccessModifier Country { get; set; }

        public AccessModifier Town { get; set; }

        public AccessModifier Address { get; set; }


        [Required]
        public Location Location { get; set; } = null!;
    }
}
