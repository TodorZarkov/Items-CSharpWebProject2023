﻿namespace Items.Web.ViewModels.Sell
{
	using Items.Web.ViewModels.Item;

	public class AllSellViewModel
	{
		public Guid ItemId { get; set; }

		public string Name { get; set; } = null!;

        public Guid MainPictureId { get; set; }

        public decimal Quantity { get; set; }

		public string Unit { get; set; } = null!;

		public string[] Categories { get; set; } = null!;


		public bool IsSell { get; set; }
		public bool IsAuction { get; set; }


		public string Place { get; set; } = null!;
		public string Location { get; set; } = null!;


        public string CurrentPrice { get; set; } = null!;
		public string Currency { get; set; } = null!;
        public string? HighestBid { get; set; } = null!;
		public int? OffersCount { get; set; }
        public int? BartersCount { get; set; }


		public string StartSell { get; set; } = null!;
		public DateTime EndSell { get; set; }


		public ItemVisibilityViewModel Visibility { get; set; } = null!;
    }
}
