using MediatR;

namespace Application.Features.Companies.Commands.Delete;

public class DeleteCompanyRequest : IRequest<DeleteCompanyResponse>
{
    public Guid Id { get; set; }

    public DeleteCompanyRequest(Guid id)
    {
        Id = id;
    }

    public DeleteCompanyRequest()
    { }
}