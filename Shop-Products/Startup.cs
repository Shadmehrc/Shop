using System.Collections.Generic;
using Application.Common;
using Application.IPhoneCrudServices;
using Application.RepositoryInterfaces;
using Application.Services;
using Infrastructore.Repository;
using Infrastructore.Sql.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            var originsList = new List<string>();
            var validOrigins = string.Empty;
            services.AddControllers();
            services.AddSingleton<DatabaseContext>();
            services.AddScoped<IPhoneCrudService, PhoneCrudService>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<IOriginRepository, OriginRepository>();
            services.AddScoped<IConfigManager, ConfigManager>();
            {
                var buildServiceProvider = services.BuildServiceProvider();
                var service = buildServiceProvider.GetService<IConfigManager>();
                if (service != null)
                {
                    originsList = service.GetOrigin();
                    originsList.ForEach(x => validOrigins += x + ',');
                }
            }
            services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin", configurePolicy =>
            {
                configurePolicy.WithOrigins(validOrigins.Split(','))
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

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
            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors("AllowOriginV2");
        }
    }
}