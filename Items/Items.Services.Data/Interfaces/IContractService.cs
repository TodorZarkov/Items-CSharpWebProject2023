﻿namespace Items.Services.Data.Interfaces
{
	using Items.Services.Data.Models.Contract;
	using Items.Web.ViewModels.Base;
	using Items.Web.ViewModels.Deal;

	public interface IContractService
	{
		Task<long> CountCompletedAsync();
		Task<AllContractServiceModel> AllAsync(Guid userId, QueryFilterModel? queryModel = null);
		Task CancelAsync(Guid id, Guid userId);
		Task<bool> CanComplainAsync(Guid id, Guid userId);
		Task<bool> CanReviseAsync(Guid id, Guid userId);
		Task ChangeReviserAsync(Guid id);
		Task CompleteAsync(Guid id, Guid userId);
		Task CopyBuyerContractImagesToItemAsync(Guid contractId, Guid itemId, IEnumerable<Guid> imagesToDelete, Guid mainImageId);
		Task CreateAsync(ContractFormViewModel previewModel, Guid itemId, Guid buyerId);
		Task<Guid> CreateAsync(ContractFormViewModel model, Guid itemId, Guid buyerId, Guid offerId);
		Task<ContractFormViewModel> GetForCreateAsync(ContractFormViewModel model, Guid itemId, Guid buyerId);
		Task<ContractFormViewModel> GetForCreateAsync(ContractFormViewModel model, Guid itemId, Guid buyerId, Guid offerId);
		Task<ContractViewModel> GetForDetailsAsync(Guid contractId);
		Task<ContractFormViewModel> GetForPreviewAsync(Guid itemId, Guid buyerId);
		Task<ContractFormViewModel> GetForPreviewAsync(Guid itemId, Guid buyerId, Guid offerId);
		Task<ContractFormViewModel> GetForRevise(Guid id, Guid userId);
		Task<bool> IsBuyerAsync(Guid dealId, Guid userId);
		Task<bool> IsSellerAsync(Guid id, Guid userId);
		Task<bool> SellerOrBuyerAsync(Guid contractId, Guid userId);
		Task SetSignedAsync(Guid id);
		Task<bool> SignedAsync(Guid id);
		Task UpdateAsync(Guid id, ContractFormViewModel model);
	}
}
