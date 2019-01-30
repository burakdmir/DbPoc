using DbPoc.Application.Validators;
using DbPoc.Infrastructure.IOC;
using DbPoc.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace DbPoc
{
  public class Startup
  {
    private readonly IConfiguration configuration;
    private readonly IHostingEnvironment hostingEnvironment;

    public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
    {
      this.configuration = configuration;
      this.hostingEnvironment = hostingEnvironment;
    }




    public IServiceProvider ConfigureServices(IServiceCollection services)
    {

      IConfigurationRoot dbConfiguration = new ConfigurationBuilder()
          .SetBasePath(hostingEnvironment.ContentRootPath)
      .AddJsonFile("dbSettings.json")
      .Build();


      services.AddTransient<IConfigurationRoot>((sp) => dbConfiguration);

      //    services.AddResponseCompression();
      services.AddMemoryCache();

      services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                         .AllowAnyMethod()
                                                                          .AllowAnyHeader()));

      services
          .AddMvc()
          .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
          .AddControllersAsServices()
          .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
          .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>());

      services.AddSwaggerGen(c =>
            {
              c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

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


      app.UseCors("AllowAll");
      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger()
        .UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      });
      app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();
      app.UseHttpsRedirection();
      app.UseMvc();

      loggerFactory.AddSerilog();
      loggerFactory.AddFile(Path.Combine(env.ContentRootPath, "Logs", "mylog-{Date}.txt"));
      //   app.UseResponseCompression();
    }
  }
}
