﻿namespace Items.Services.Data
{
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Home;
	using System.Collections.Generic;
	using Common.Enums;
	using Microsoft.EntityFrameworkCore;

	public class ItemService : IItemService
	{
		private readonly ItemsDbContext dbContext;

        public ItemService(ItemsDbContext dbContext)
        {
			this.dbContext = dbContext;   
        }


        public async Task<IEnumerable<IndexViewModel>> LastPublicItemsAsync(int numberOfItems)
		{
			IEnumerable<IndexViewModel> lastThree = await dbContext.Items
				.Where(i => i.Access == AccessModifier.Public &&
							(i.EndSell == null || i.EndSell > DateTime.UtcNow))
				.OrderByDescending(i => i.AddedOn)
				.Take(numberOfItems)
				.Select(i => new IndexViewModel
				{
					Id = i.Id,
					Name = i.Name,
					MainPictureUri = i.Pictures.First(p => p.IsMain).Uri,
					CurrentPrice = i.CurrentPrice,
					CurrencySymbol = i.Currency == null ? null : i.Currency.Symbol,
					IsAuction = i.IsAuction
				})
				.ToArrayAsync();

			return lastThree;
		}
	}
}
