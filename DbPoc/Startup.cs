using DbPoc.Infrastructure.IOC;
using DbPoc.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;

namespace DbPoc
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment hostingEnvironment;

        public Startup(IConfiguration configuration,IHostingEnvironment hostingEnvironment)
        {
            this.configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        }

        


        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<DbPocDbContext>(options =>
            // options.UseSqlServer(Configuration.GetConnectionString("DbPocDatabase")));


            IConfigurationRoot dbConfiguration = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
            .AddJsonFile("dbSettings.json")
            //.AddJsonFile($"appsettings.Local.json", optional: true)
            //.AddJsonFile($"appsettings.{environmentName}.json", optional: true)
            .Build();

            services.AddTransient<IConfigurationRoot>((sp)=> dbConfiguration);
            services
                .AddMvc()
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            return Bootstrap.Initialize(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            loggerFactory.AddSerilog();
            loggerFactory.AddFile(Path.Combine(env.ContentRootPath, "Logs","mylog-{Date}.txt"));

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
