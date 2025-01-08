using Application.Features.Companies.Commands.Create;
using Application.Features.Companies.Commands.Delete;
using Application.Features.Companies.Commands.Update;
using Application.Features.Companies.Queries.GetAll;
using Application.Features.Companies.Queries.GetById;
using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, CreateUserRequest>().ReverseMap();
            CreateMap<User, CreateUserResponse>().ReverseMap();
            CreateMap<User, DeleteUserRequest>().ReverseMap();
            CreateMap<User, DeleteUserResponse>().ReverseMap();
            CreateMap<User, UpdateUserRequest>().ReverseMap();
            CreateMap<User, UpdateUserResponse>().ReverseMap();
            CreateMap<User, GetAllUserRequest>().ReverseMap();
            CreateMap<User, GetAllUserResponse>().ReverseMap();
            CreateMap<User, GetByIdUserRequest>().ReverseMap();
            CreateMap<User, GetByIdUserResponse>().ReverseMap();
        }
    }
}