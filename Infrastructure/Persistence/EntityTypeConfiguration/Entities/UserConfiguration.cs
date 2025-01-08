using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityTypeConfiguration.Common;
using System.Security.Cryptography;
using System.Text;

namespace Persistence.EntityTypeConfiguration.Entities
{
	public class UserConfiguration : BaseConfiguration<User, Guid>
	{
		
		protected override void ConfigureImplementation(EntityTypeBuilder<User> builder)
		{
			var password = "DefaultPassword";
			CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

			builder.ToTable("Users");
			builder.HasData(
				new User
				{
					Id = Guid.Parse("a6cec149-f87b-43e0-b4e8-43fa24e05c58"),
					Name = "Default Name",
					Description = "Default Description",
					CreatedDate = DateTime.UtcNow,
					LastUpdatedDate = DateTime.UtcNow,
					Email = "Default@gmail.com",
					PasswordSalt = passwordSalt,
					PasswordHash = passwordHash,
				
				}

				);
		}

		private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
			}


		}


	}
}
