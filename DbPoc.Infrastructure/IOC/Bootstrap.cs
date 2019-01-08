using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DbPoc.Infrastructure.IOC
{
    public static class Bootstrap
    {

        public static IServiceProvider Initialize(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterAssemblyModules();
            return new AutofacServiceProvider(builder.Build());
        }
    }
}
