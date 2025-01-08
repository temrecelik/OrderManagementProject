using System.Reflection;
using Application.Interceptors;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Module = Autofac.Module;

namespace Application;

public class AutofacApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
    }
}