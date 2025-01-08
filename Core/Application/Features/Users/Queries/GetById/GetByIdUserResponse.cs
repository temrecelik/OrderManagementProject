namespace Application.Features.Users.Queries.GetById;

public class GetByIdUserResponse
{
    public Guid Id { get; set; }
   
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
}