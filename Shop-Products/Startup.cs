using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.IPhoneCrudServices;
using Application.RepositoryInterfaces;
using Application.Services;
using Infrastructore.Repository;
using Infrastructore.Sql.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Shop_Products
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

            services.AddControllers();
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowOrigin", configurePolicy =>
            //    {
            //        configurePolicy
            //            .WithOrigins("http://192.168.1.2:8080")
            //            .AllowAnyHeader()
            //            .AllowAnyMethod();
            //    });
            //});
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOriginV2", configurePolicy => configurePolicy.AllowAnyOrigin());
            });
            services.AddSingleton<DatabaseContext>();
            services.AddScoped<IPhoneCrudService, PhoneCrudService>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shop_Products", Version = "v1" });
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop_Products v1"));
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseCors("AllowOrigin");
            app.UseCors("AllowOriginV2");
        }
    }
}
