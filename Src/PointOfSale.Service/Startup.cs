using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PointOfSale.DataAccess;
using PointOfSale.DataAccess.Interfaces;
using PointOfSale.Interfaces;
using PointOfSale.Service.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(x => 
            {
                x.Filters.Add(typeof(JsonExceptionFilter));
            });

            services.AddSingleton<IProductRepository, ProductRepository>();

            services.AddSingleton<IPriceRepository, PriceRepository>();
            
            services.AddSingleton<IPurchaseRepository, PurchaseRepository>();
            
            services.AddScoped<IPointOfSaleTerminalService, PointOfSaleTerminalService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
