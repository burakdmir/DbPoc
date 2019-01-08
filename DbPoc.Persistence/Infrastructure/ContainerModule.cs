using Autofac;
using Microsoft.Extensions.Configuration;
using System;

namespace DbPoc.Persistence.Infrastructure
{
    class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //services.AddDbContext<DbPocDbContext>(options =>
            // options.UseSqlServer(Configuration.GetConnectionString("NorthwindDatabase")));

            builder.Register<DbPocDbContext>((cc) =>
            {
                IConfigurationRoot configurationRoot = cc.Resolve<IConfigurationRoot>();
                return new DbPocDbContextFactory().CreateDbContext(new[] { configurationRoot.GetConnectionString("DbPocDatabase") });

            });
        }
    }
}
