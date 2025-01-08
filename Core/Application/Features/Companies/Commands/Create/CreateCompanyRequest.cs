using MediatR;

namespace Application.Features.Companies.Commands.Create;

public class CreateCompanyRequest : IRequest<CreateCompanyResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
}