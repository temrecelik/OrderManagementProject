using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityTypeConfiguration.Common;

namespace Persistence.EntityTypeConfiguration.Entities
{
	public class CompanyConfiguration : BaseConfiguration<Company, Guid>
	{


	protected override void ConfigureImplementation(EntityTypeBuilder<Company> builder)
	{
		builder.ToTable("Companies");

		builder.HasData(
			new Company
			{
				Id = Guid.Parse("d8d6dad3-c8fc-443e-a02b-24ae0b9df15c"),
				Name = "Default Company",
				Description = "Default Description",
				CreatedDate = DateTime.UtcNow,
				LastUpdatedDate = DateTime.UtcNow,
			

			}
		);
	}
}
}
