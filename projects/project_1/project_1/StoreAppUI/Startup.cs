using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreAppBusinessLayer;
using StoreAppModelsLayer.Interfaces;
using StoreAppModelsLayer.EFModels;
using StoreAppDBContextLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace StoreAppUI
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreAppUI", Version = "v1" });
      });

      services.AddDbContext<StoreApplicationDBContext>(options =>
      {
        //If db options is already configured, do nothing.
        //Otherwise, use the ConnectionStrings in secrets.json.
        if (!options.IsConfigured)
        {
          options.UseSqlServer(Configuration.GetConnectionString("DevDb"));
        }
      });

      //registering classes with the DI system
      services.AddScoped<IRepository<Customer>, CustomerRepository>();
      services.AddScoped<IRepository<Product>, ProductRepository>();
      services.AddScoped<ICustomerManager, CustomerManager>();
      services.AddScoped<IRepository<Location>, LocationRepository>();
      services.AddScoped<IManager<Location>, LocationManager>();
      services.AddScoped<IManager<Product>, ProductManager>();
      services.AddScoped<IProductRepository, ProductRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreAppUI v1"));
      }

      app.UseHttpsRedirection();

      app.UseStaticFiles();

      //redirect to index HTML
      app.UseRewriter(new RewriteOptions()
        .AddRedirect("^$", "index.html"));

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
