﻿namespace Items.Data.Configurations
{
	using Items.Data.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class ItemVisibilityEntityConfiguration : IEntityTypeConfiguration<ItemVisibility>
	{
		public void Configure(EntityTypeBuilder<ItemVisibility> builder)
		{
			builder
				.HasData(GenerateItemVisibilities());
		}

		private ItemVisibility[] GenerateItemVisibilities()
		{
			List<ItemVisibility> itemVisibilities = new List<ItemVisibility>();

			ItemVisibility itemVisibility = new ItemVisibility
			{
				Id = Guid.Parse("8D725141-2B5A-468F-9E1E-61AB0C7F8F5E")
			};
			itemVisibilities.Add(itemVisibility);
			
			itemVisibility = new ItemVisibility
			{
				Id = Guid.Parse("A78C2EDA-79CB-4ACC-A7E4-92E0B45E20EB")
			};
			itemVisibilities.Add(itemVisibility);
			
			itemVisibility = new ItemVisibility
			{
				Id = Guid.Parse("0FB06C25-8E6F-4FD2-A1D9-3CEBB4621D2E")
			};
			itemVisibilities.Add(itemVisibility);
			
			itemVisibility = new ItemVisibility
			{
				Id = Guid.Parse("A33DD8ED-4619-4D18-A25C-2BB25B7BB456")
			};
			itemVisibilities.Add(itemVisibility);
			
			itemVisibility = new ItemVisibility
			{
				Id = Guid.Parse("D009129E-5655-4CD2-BA67-114E2E792B8C")
			};
			itemVisibilities.Add(itemVisibility);
			
			itemVisibility = new ItemVisibility
			{
				Id = Guid.Parse("C0BBCABF-5C24-4CA6-86BC-ECA11AE46EB8")
			};
			itemVisibilities.Add(itemVisibility);
			
			itemVisibility = new ItemVisibility
			{
				Id = Guid.Parse("61C89A18-8BDA-4D12-9A70-CDB17AEDD752")
			};
			itemVisibilities.Add(itemVisibility);
			
			itemVisibility = new ItemVisibility
			{
				Id = Guid.Parse("CBD7BD12-AA21-4E33-95CF-FD9C342DB010")
			};
			itemVisibilities.Add(itemVisibility);
			
			itemVisibility = new ItemVisibility
			{
				Id = Guid.Parse("49ABFA42-69F7-4240-A2EF-4E1B3EF7C16C")
			};
			itemVisibilities.Add(itemVisibility);



			return itemVisibilities.ToArray();
		}
	}
}
