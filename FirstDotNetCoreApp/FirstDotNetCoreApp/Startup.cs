using FirstDotNetCoreApp.BusinessLayer.Services;
using FirstDotNetCoreApp.BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using FirstDotNetCoreApp.Helpers;
using FirstDotNetCoreApp.DataAccess;
using FirstDotNetCoreApp.DataAccess.Repositories;
using FirstDotNetCoreApp.DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FirstDotNetCoreApp
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
            services.AddDbContext<MyDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Practice API",
                    Description = "First .NET Core application",
                    Version = "v1"
                });

                c.OperationFilter<FileUploadOperation>(); //Register File Upload Operation Filter
            });

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IFormFileRepository, FormFileRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IFormFileService, FormFileService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Practice API V1");
            });

            app.UseMvc();
        }
    }
}
