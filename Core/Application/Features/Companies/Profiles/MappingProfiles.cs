using Application.Features.Companies.Commands.Create;
using Application.Features.Companies.Commands.Delete;
using Application.Features.Companies.Commands.Update;
using Application.Features.Companies.Queries.GetAll;
using Application.Features.Companies.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Companies.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Company, CreateCompanyRequest>().ReverseMap();
        CreateMap<Company, CreateCompanyResponse>().ReverseMap();
        CreateMap<Company, DeleteCompanyRequest>().ReverseMap();
        CreateMap<Company, DeleteCompanyResponse>().ReverseMap();
        CreateMap<Company, UpdateCompanyRequest>().ReverseMap();
        CreateMap<Company, UpdateCompanyResponse>().ReverseMap();
        CreateMap<Company, GetAllCompanyRequest>().ReverseMap();
        CreateMap<Company, GetAllCompanyResponse>().ReverseMap();
        CreateMap<Company, GetByIdCompanyRequest>().ReverseMap();
        CreateMap<Company, GetByIdCompanyResponse>().ReverseMap();
    }
}