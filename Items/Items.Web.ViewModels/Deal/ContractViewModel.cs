﻿namespace Items.Web.ViewModels.Deal
{
	using Items.Web.Validators.Attributes;

	public class ContractViewModel
	{
		public bool? IsSeller { get; set; }
		public string? SellerName { get; set; } 
		public string? SellerEmail { get; set; }
		public string? SellerPhone { get; set; }

		public string? BuyerName { get; set; }
		public string? BuyerEmail { get; set; }
		public string? BuyerPhone { get; set; }

		public string TotalPrice { get; set; } = null!;

        public decimal Price { get; set; }

		public string CurrencySymbol { get; set; } = null!;

		public string UnitSymbol { get; set; } = null!;

		public string ItemName { get; set; } = null!;

		public Guid ItemMainPictureId { get; set; }

		public string? ItemDescription { get; set; }


		public decimal Quantity { get; set; }

		public DateTime SendDue { get; set; } //modifiable

		public DateTime DeliverDue { get; set; }//modifiable

		public string? SellerComment { get; set; } //modifiable

		public string? BuyerComment { get; set; } //modifiable

		public string DeliveryAddress { get; set; } = null!; //modifiable


		
		public string? BarterName { get; set; } = null!;

		public Guid? BarterPictureId { get; set; }

		public string? BarterDescription { get; set; }

		public decimal? BarterQuantity { get; set; }

		public string? BarterUnitSymbol { get; set; }

		public Guid? BarterId { get; set; }
	}
}
