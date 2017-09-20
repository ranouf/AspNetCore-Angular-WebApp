using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System;
using Test1.Core;
using Test1.Infrastructure;
using Test1.Infrastructure.EntityFramework;
using AutoMapper;
using Test1.Web.Controllers.Sample;

public class Startup
{
  private readonly IHostingEnvironment _hostingEnvironment;

  public Startup(IHostingEnvironment env)
  {
    _hostingEnvironment = env;

    var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();
    Configuration = builder.Build();
  }

  public IConfigurationRoot Configuration { get; }

  public IContainer ApplicationContainer { get; private set; }

  // This method gets called by the runtime. Use this method to add services to the container.
  public IServiceProvider ConfigureServices(IServiceCollection services)
  {
    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    // Add framework services.
    services.AddMvc();

    //Swagger-ui 
    services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new Info {
        Title = "Test 1",
        Version = "v1",
        Description = "Welcome to the marvellous Test1 API!" });
    });

    //Automapper
    services.AddAutoMapper(cfg =>
    {
      cfg.AddProfile(new SampleProfile());
    });

    // Autofac
    var builder = new ContainerBuilder();
    builder.RegisterModule(new CoreModule());
    builder.RegisterModule(new InfrastructureModule());
    builder.Populate(services);
    ApplicationContainer = builder.Build();

    return new AutofacServiceProvider(this.ApplicationContainer);
  }

  // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
  public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
  {
    // only enable webpack building in Developement environment
    if (env.IsDevelopment())
    {
      //Swagger-ui
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test1 V1");
      });

      app.UseDeveloperExceptionPage();
      app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
      {
        HotModuleReplacement = true
      });
    }

    app.UseStaticFiles();

    loggerFactory.AddConsole(Configuration.GetSection("Logging"));
    loggerFactory.AddDebug();

    app.UseMvc(routes =>
    {
      routes.MapRoute(
          name: "default",
          template: "api/{controller}/{id?}");
      // add a special route for our index page
      routes.MapSpaFallbackRoute(
          name: "spa-fallback",
          defaults: new { controller = "Home", action = "index" });
    });
  }
}
