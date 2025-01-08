using Domain.Entities.Common;

namespace Domain.Entities;

public class User : BaseDescEntity<Guid>
{

    public ICollection<Order>? Orders { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public byte[]? PasswordHash { get; set; }
    public string? Email { get; set; }
}