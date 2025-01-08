using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityTypeConfiguration.Common;

namespace Persistence.EntityTypeConfiguration.Entities
{
	public class ProductConfiguration : BaseConfiguration<Product, Guid>
	{
		protected override void ConfigureImplementation(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("Products");
			builder.HasData(
				new Product
				{
					Id = Guid.Parse("b520d963-aad4-4df9-b0ec-e89f5c82d52d"),
					Name = "Default Name",
					Description = "Default Description",
					CreatedDate = DateTime.UtcNow,
					LastUpdatedDate = DateTime.UtcNow,
					StockCount = 100,
					Price = 100,
					CompanyId = Guid.Parse("d8d6dad3-c8fc-443e-a02b-24ae0b9df15c"),
					ProductCategoryId = Guid.Parse("a248dbf5-34d2-402c-b5d4-b882911d8768")

				}

				);

		}
	}
}
