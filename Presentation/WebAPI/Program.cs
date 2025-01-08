using Application;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Infrastructure;
using Persistence;
using WebAPI.Middleware;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. //
            builder.Services.AddApplicationService();
            builder.Services.AddInfrastructureServices();
            builder.Services.AddPersistenceServices();
            // Add services to the container. //

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder => 
                builder.RegisterModule(new AutofacApplicationModule()));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            if (app.Environment.IsProduction())
                app.ConfigureExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
