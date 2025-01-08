using Application.Features.Companies.Commands.Create;
using Application.Features.Orders.Commands.Create;
using Application.Features.Orders.Queries.GetAll;
using Application.Features.Orders.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Orders.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //CreateMap<CreateOrderRequest, Order>()
        //    .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products.Select(guid => new Product { Id = guid })));

        CreateMap<Order, CreateOrderRequest>().ReverseMap();
        CreateMap<Order, CreateOrderResponse>().ReverseMap();
		CreateMap<Order, GetAllOrderRequest>().ReverseMap();
		CreateMap<Order, GetAllOrderResponse>().ReverseMap();
		CreateMap<Order, GetByIdOrderRequest>().ReverseMap();
		CreateMap<Order, GetByIdOrderResponse>().ReverseMap();
	}
}