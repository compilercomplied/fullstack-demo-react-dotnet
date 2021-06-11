using application.builder.Injection.Extensions;
using application.builder.Middleware;
using domain.mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TranslateApi
{

  public class Startup
  {

    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {

      // --- Application configuration -----------------------------------------
      services.AddControllers();
      services.AddSwaggerGen(c =>
      {

        c.SwaggerDoc("v1", new OpenApiInfo 
        { 
          Title = "Translate Demo API", 
          Version = "v1",
        });

      });

      services.AddCors(opts =>
      {
        opts.AddDefaultPolicy(builder => { builder.WithOrigins("*"); });
      });

      services.AddAutoMapper(typeof(MappingInitialization));


      // --- Application builder definitions -----------------------------------
      services
        .ConfigureDomainServices()
        .ConfigureProviderServices();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

      app.UseMiddleware<ExceptionMiddleware>();

      app.UseSwagger();
      app.UseSwaggerUI(c => 
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TranslateApi v1")
      );

      app.UseRouting();

      app.UseCors(opts => opts
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
      );

      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

    }

  }

} 