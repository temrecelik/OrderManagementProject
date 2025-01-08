namespace Application.Features.Companies.Commands.Create;

public class CreateCompanyResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}