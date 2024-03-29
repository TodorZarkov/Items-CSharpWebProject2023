﻿namespace Items.Web.ViewModels.Offer
{
	public class AllOfferViewModel
	{
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public Guid Id { get; set; }

		public string Expires { get; set; } = null!;

		public string? Message { get; set; }


		public decimal Quantity { get; set; }
		public string UnitSymbol { get; set; } = null!;
        public decimal Value { get; set; }
		public string CurrencySymbol { get; set; } = null!;


        public Guid? BarterPictureId { get; set; }
        public string? BarterName { get; set; }
		public string? BarterQuantity { get; set; }
		public string? BarterUnit { get; set; }
        public string? BarterDescription { get; set; }
		public Guid? BarterItemId { get; set; }
    }
}
