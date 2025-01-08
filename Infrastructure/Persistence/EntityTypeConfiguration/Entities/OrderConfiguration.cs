using Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityTypeConfiguration.Common;

namespace Persistence.EntityTypeConfiguration.Entities
{
	public class OrderConfiguration : BaseConfiguration<Order, Guid>
	{



		protected override void ConfigureImplementation(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("Orders");

			builder.HasData(
				new Order
				{
					Id = Guid.Parse("3419f0b4-29ed-4603-a6af-80838c5cacdd"),
					Name = "Default Company",
					CreatedDate = DateTime.UtcNow,
					LastUpdatedDate = DateTime.UtcNow,
					ProductCount = 100,
					UnitPrice = 10,
					CompanyId = Guid.Parse("d8d6dad3-c8fc-443e-a02b-24ae0b9df15c"),
					TotalPrice = 1000,
					OrderStatus = Domain.Enums.OrderStatus.Pending,
					UserId = Guid.Parse("a6cec149-f87b-43e0-b4e8-43fa24e05c58")

				});

			builder.HasMany(o => o.Products)
			   .WithMany(p => p.Orders)
			   .UsingEntity<Dictionary<Guid, object>>(
			   "OrderProduct",
			   opp => opp.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
			   opo => opo.HasOne<Order>().WithMany().HasForeignKey("OrderId"),
			   je =>
			   {
				   je.HasKey("ProductId", "OrderId");
				   je.HasData(
					   new { ProductId = Guid.Parse("b520d963-aad4-4df9-b0ec-e89f5c82d52d"), OrderId = Guid.Parse("3419f0b4-29ed-4603-a6af-80838c5cacdd") }

					   );
			   }
			   );


		}
	}
}
