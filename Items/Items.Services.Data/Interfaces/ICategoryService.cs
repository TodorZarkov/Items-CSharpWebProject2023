﻿namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Category;

	public interface ICategoryService
	{
		Task<ICollection<CategoryFilterViewModel>> GetAllPublicAsync();
		Task<ICollection<CategoryFilterViewModel>> GetMineAsync(Guid userId);
		Task<IEnumerable<CategoryFilterViewModel>> AllForSelectAsync(Guid userId);


		Task<ICollection<int>> GetAllIdsAsync();
		
		Task<ICollection<int>> GetAllPublicIdsAsync();

		Task<int> AddAsync(CategoryFormViewModel model, Guid userId);

		Task<IEnumerable<ForSelectCategoryViewModel>> GetForSelectAsync(Guid? userId = null);


		Task<bool> IsAllowedIdsAsync(int[] ids, Guid userId);
		Task<bool> IsAllowedPublicIdsAsync(int[] ids);
		Task<bool> ExistNameAsync(string name, Guid userId, Guid );

	}
}
