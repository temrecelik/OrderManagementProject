using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityTypeConfiguration.Common;

namespace Persistence.EntityTypeConfiguration.Entities
{
	public class ProductCategoryConfiguration : BaseConfiguration<ProductCategory, Guid>
	{
	

		protected override void ConfigureImplementation(EntityTypeBuilder<ProductCategory> builder)
		{
			builder.ToTable("ProductCategories");
			builder.HasData(
			 new ProductCategory
			 {
				 Id = Guid.Parse("a248dbf5-34d2-402c-b5d4-b882911d8768"),
				 Name = "Default Company",
				 Description = "Default Description",
				 CreatedDate = DateTime.UtcNow,
				 LastUpdatedDate = DateTime.UtcNow,

			 }
			);
		}
	}
}
