namespace Domain.Entities.Common;

public class BaseDescEntity<TId> : BaseEntity<TId>
{
    public string? Description { get; set; }
}