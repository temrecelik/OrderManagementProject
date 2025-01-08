using MediatR;

namespace Application.Features.Companies.Queries.GetById;

public class GetByIdCompanyRequest : IRequest<GetByIdCompanyResponse>
{
    public Guid Id { get; set; }

    public GetByIdCompanyRequest(Guid id)
    {
        Id = id;
    }

    public GetByIdCompanyRequest()
    { }
}