using Application.Services;
using Infrastructure.Cache.Microsoft;
using Infrastructure.Mailing;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection service)
    {
        //service.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
        service.AddTransient<IMailService,MailService>();

        //cashing için
		service.AddMemoryCache();
		service.AddScoped<ICacheService, MemoryCacheService>();

	}
}