﻿namespace Items.Data.Models
{
    using static Common.EntityValidationConstants.Picture;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Picture
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength()]
        public string Uri { get; set; } = null!;

        public bool IsMain { get; set; }

        [Required]
        [ForeignKey(nameof(Item))]
        public Guid ItemId { get; set; }

        public Item Item { get; set; }
    }
}