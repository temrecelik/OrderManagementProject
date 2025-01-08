using Application.Features.ProductCategories.Commands.Create;
using Application.Features.ProductCategories.Commands.Delete;
using Application.Features.ProductCategories.Commands.Update;
using Application.Features.ProductCategories.Queries.GetAll;
using Application.Features.ProductCategories.Queries.GetById;
using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.ProductCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductCategory, CreateProductCategoryRequest>().ReverseMap();
        CreateMap<ProductCategory, CreateProductCategoryResponse>().ReverseMap();
        CreateMap<ProductCategory, DeleteProductCategoryRequest>().ReverseMap();
        CreateMap<ProductCategory, DeleteProductCategoryResponse>().ReverseMap();
        CreateMap<ProductCategory, UpdateProductCategoryRequest>().ReverseMap();
        CreateMap<ProductCategory, UpdateProductCategoryResponse>().ReverseMap();
        CreateMap<ProductCategory, GetAllProductCategoryRequest>().ReverseMap();
        CreateMap<ProductCategory, GetAllProductCategoryResponse>().ReverseMap();
        CreateMap<ProductCategory, GetByIdProductCategoryRequest>().ReverseMap();
        CreateMap<ProductCategory, GetByIdProductCategoryResponse>().ReverseMap();
    }
}