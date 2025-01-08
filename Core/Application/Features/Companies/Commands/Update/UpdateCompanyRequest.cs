using MediatR;

namespace Application.Features.Companies.Commands.Update;

public class UpdateCompanyRequest : IRequest<UpdateCompanyResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}