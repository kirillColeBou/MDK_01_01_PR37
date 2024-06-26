using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop_Тепляков.Data.Interfaces;
using Shop_Тепляков.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Тепляков
{
    public class Startup
    {
        public static List<ItemsBasket> BasketItem = new List<ItemsBasket>();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICategorys, Data.DataBase.DBCategory>();
            services.AddTransient<IItems, Data.DataBase.DBItems> ();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".less"] = "text/css";
            app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = provider});
            app.UseMvcWithDefaultRoute();
        }
    }
}
