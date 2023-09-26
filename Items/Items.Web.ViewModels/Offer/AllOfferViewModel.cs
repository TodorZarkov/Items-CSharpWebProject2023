﻿namespace Items.Web.ViewModels.Offer
{
	public class AllOfferViewModel
	{
		public Guid OfferId { get; set; }

		public string Expires { get; set; } = null!;

		public string? Message { get; set; }


		public decimal QuantityToBuy { get; set; }
		public decimal ValuePerQuantity { get; set; }


		public string? BarterQuantity { get; set; }
		public string? BarterUnit { get; set; }
		public Guid? BarterItemId { get; set; }
		public string? BarterPictureUri { get; set; }
		public string? BarterName { get; set; }
	}
}
