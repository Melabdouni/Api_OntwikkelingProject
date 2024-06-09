using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using MVC_Deel1.Services;
using Microsoft.AspNetCore.Hosting;


using Newtonsoft.Json;
using MVC_Deel1.Entities;
using Microsoft.EntityFrameworkCore;

namespace MVC_Deel1
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            });
            services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        });

            services.AddControllers();
            services.AddScoped<IBuildingData, InMemoryBuildingData>();
            services.AddScoped<IUserData, InMemoryUserData>();
            services.AddScoped<IUtilityData, InMemoryUtilityData>();
            services.AddSwaggerGen();
            var connection = "server=localhost; database=vastgoedBeheer-db; user=root; password= root";
            services.AddDbContext<MVCDbContext>(
                x => x.UseMySql(connection, ServerVersion.AutoDetect(connection)));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)

        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("./swagger/v1/swagger.json", "VastgoedBeheer");
                    c.RoutePrefix = string.Empty;
                });

            }
            else 
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = context=> context.Response.WriteAsync( "Error herbekijk je code" )
                }); ;
            
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseFileServer();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                /* endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");*/
                endpoints.MapControllers();

            });
        }
    }
} 
