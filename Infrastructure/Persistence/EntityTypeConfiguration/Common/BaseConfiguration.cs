using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfiguration.Common
{
	public abstract class BaseConfiguration<T, TKey> : IEntityTypeConfiguration<T>
		where TKey : struct
		where T : BaseEntity<TKey>
	{
		public void Configure(EntityTypeBuilder<T> builder)
		{
			builder.HasKey(x => x.Id);
			ConfigureImplementation(builder);
		}

		protected abstract void ConfigureImplementation(EntityTypeBuilder<T> builder);

	}
}
