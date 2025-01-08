namespace Domain.Entities.Common;

public class BaseEntity<TId>
{
    public TId? Id { get; set; }
    public string Name { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }

}