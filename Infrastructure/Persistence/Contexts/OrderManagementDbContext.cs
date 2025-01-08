using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Entities.Common;
using System.Reflection;


namespace Persistence.Contexts
{
	public class OrderManagementDbContext : DbContext
	{
		public OrderManagementDbContext(DbContextOptions options) : base(options)
		{ }

		public DbSet<Company> Companies { get; set; }
		public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<User> Users { get; set; }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
			}
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}


        //SaveChangesAsync metodu çağırıldığında ekleme veya güncelleme işlemi yapıldıysa database de ilgili alanların doldurulması için metodu override ediyoruz
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
			var datas = ChangeTracker.Entries<BaseEntity<Guid>>();
			foreach (var data in datas)
			{
				_ = data.State switch
				{
					EntityState.Added => data.Entity.CreatedDate = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", null),
					EntityState.Modified => data.Entity.LastUpdatedDate = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", null),
					_ => DateTime.ParseExact(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", null)
				};
			}
			return await base.SaveChangesAsync(cancellationToken);
		}
	}
}
