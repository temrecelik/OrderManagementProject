using Application.Repositories.CompanyRepository;
using Application.Repositories.OrderRepository;
using Application.Repositories.ProductCategoryRepository;
using Application.Repositories.ProductRepository;
using Application.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Concretes.CompanyRepository;
using Persistence.Concretes.OderRepository;
using Persistence.Concretes.ProductCategoryRepository;
using Persistence.Concretes.ProductRepository;
using Persistence.Concretes.UserRepository;
using Persistence.Contexts;

namespace Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<OrderManagementDbContext>(options => options.UseSqlServer(Configuration.ConnectionString!));
               
        services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
        services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IProductCategoryReadRepository, ProductCategoryReadRepository>();
        services.AddScoped<IProductCategoryWriteRepository, ProductCategoryWriteRepository>();
        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();

        services.AddScoped<ICompanyUnitOfWork, CompanyUnitOfWork>();
        services.AddScoped<IOrderUnitOfWork, OrderUnitOfWork>();
        services.AddScoped<IProductCategoryUnitOfWork, ProductCategoryUnitOfWork>();
        services.AddScoped<IProductUnitOfWork, ProductUnitOfWork>();
        services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
    }
}