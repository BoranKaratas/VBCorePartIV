using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using shop.API.HealthChecks;
using shop.API.Middlewares;
using shop.Business;
using shop.Business.Profiles;
using Shop.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.API
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "shop.API", Version = "v1" });
            });

            services.AddDbContext<vakifShopDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("db")));

            services.AddAutoMapper(typeof(MapProfile));
            services.AddScoped<IProductService, ProductService>();
            services.AddCors(opt => opt.AddPolicy("Allow", policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();                
            }));

            services.AddHealthChecks().AddSqlServer(Configuration.GetConnectionString("db"))
                                      .AddCheck<CustomHealthChecks>("custom");
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Run
            //app.Use()
            //app.Map("/test",builder=> builder.ru)

            app.UseMiddleware<HandleBrowserRequest>();
        
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "shop.API v1"));
            }



            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors("Allow");

            app.UseAuthorization();
            app.UseHealthChecks("/health");
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
