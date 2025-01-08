using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetAll;
using Application.Features.Products.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Products.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, CreateProductRequest>().ReverseMap();
        CreateMap<Product, CreateProductResponse>().ReverseMap();
        CreateMap<Product, DeleteProductRequest>().ReverseMap();
        CreateMap<Product, DeleteProductResponse>().ReverseMap();
        CreateMap<Product, UpdateProductRequest>().ReverseMap();
        CreateMap<Product, UpdateProductResponse>().ReverseMap();
        CreateMap<Product, GetAllProductRequest>().ReverseMap();
        CreateMap<Product, GetAllProductResponse>().ReverseMap();
        CreateMap<Product, GetByIdProductRequest>().ReverseMap();
        CreateMap<Product, GetByIdProductResponse>().ReverseMap();
    }
}