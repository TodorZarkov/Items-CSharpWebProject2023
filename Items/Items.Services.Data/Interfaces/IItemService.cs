﻿namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Home;
	using Items.Web.ViewModels.Item;
	using Items.Web.ViewModels.Sell;

	public interface IItemService
	{
		Task<IEnumerable<IndexViewModel>> LastPublicItemsAsync(int numberOfItems);


		Task<IEnumerable<AllItemViewModel>> GetByCategoriesOnSaleItemsAsync(
			int[] categories, Guid? userId);

		Task<IEnumerable<AllItemViewModel>> GetByCategoriesMineItemsAsync(
			int[] categories, Guid userId);

		Task<IEnumerable<AllItemViewModel>> GetByCategoriesAllItemsAsync(
			int[] categories, Guid userId);

		Task<IEnumerable<AllItemViewModel>> AllPublic();

		Task<IEnumerable<AllItemViewModel>> All(Guid userId);


		Task<IEnumerable<MyItemViewModel>> Mine(Guid userId);


		Task<IEnumerable<ItemForBarterViewModel>> MyAvailableForBarter(Guid userId);

		Task<IEnumerable<AllSellViewModel>> MyAllOnMarket(Guid userId);

		Task<IEnumerable<OnRotationViewModel>> GetDailyRotationsAsync(Guid userId);

		Task SetDailyRotationsAsync(Guid userId, int numberOfItems);



		Task CreateItemAsync(ItemFormModel itemFormViewModel, Guid userId);

		Task<ItemFormModel> GetByIdForEditAsync(Guid itemId);

		Task<ItemViewModel> GetByIdForViewAsync(Guid itemId);
		Task<ItemViewModel> GetByIdForViewAsOwnerAsync(Guid itemId);

		Task<bool> IsAuthorizedAsync(Guid itemId, Guid userId);
		Task<bool> IsAuthorizedToViewAsync(Guid itemId, Guid userId);


		Task UpdateItemAsync(ItemFormModel model, Guid itemId);
		Task<bool> IsOnMarketAsync(Guid id);
		Task<PreDeleteItemViewModel> GetForDeleteByIdAsync(Guid id);
		Task DeleteByIdAsync(Guid id);
		Task<bool> ExistAsync(Guid id);
		Task<bool> IsAuctionAsync(Guid id);
		Task StopSellByItemIdAsync(Guid id);
		Task<AuctionFormModel> GetForAuctionUpdateAsync(Guid id);
		Task AuctionUpdateAsync(AuctionFormModel model, Guid id);
		Task<bool> IsOwnerAsync(Guid id, Guid buyerId);
		Task<bool> HasQuantity(Guid id);
		Task<bool> SufficientQuantity(Guid itemId, decimal quantity);
	}
}
