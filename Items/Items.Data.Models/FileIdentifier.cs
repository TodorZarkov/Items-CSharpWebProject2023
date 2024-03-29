﻿namespace Items.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class FileIdentifier
	{
		[Key]
        public Guid FileId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
        public Guid? CoOwnerId { get; set; }

        [Required]
        public bool IsPublic { get; set; }



        [ForeignKey(nameof(Item))]
        public Guid? ItemId { get; set; }
		public Item? Item { get; set; }


        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }
        public ApplicationUser? User { get; set; }


        /// <summary>
        /// It is for the Item images
        /// </summary>
        [ForeignKey(nameof(BuyerContract))]
        public Guid? BuyerContractId { get; set; }
        public Contract? BuyerContract { get; set; }


        /// <summary>
        /// It is for the Barter Item images
        /// </summary>
		[ForeignKey(nameof(SellerContract))]
		public Guid? SellerContractId { get; set; }
		public Contract? SellerContract { get; set; }


        [ForeignKey(nameof(Document))]
        public Guid? DocumentId { get; set; }
        public Document? Document { get; set; }



    }
}
