using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectBackEnd.Data;
using ProjectBackEnd.Data.Repositories;
using ProjectBackEnd.Models;

namespace ProjectBackEnd
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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("QuoteContext")));

            services.AddScoped<ApplicationDataInitializer>();
            services.AddScoped<IAuteurRepository, AuteurRepository>();
            services.AddScoped<IOpmerkingRepository, OpmerkingRepository>();
            services.AddScoped<IQuoteRepository, QuoteRepository>();

            // Swagger
            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "apidocs";
                c.Title = "Quote API";
                c.Version = "v1";
                c.Description = "The Quote API documentation description.";
            }); //for OpenAPI 3.0 else AddSwaggerDocument();

            //CORS
            services.AddCors(options =>
            options.AddPolicy("AllowAllOrigins", builder =>
            builder.AllowAnyOrigin()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDataInitializer ApplicationDataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ApplicationDataInitializer.InitializeData();

            //CORS
            app.UseCors("AllowAllOrigins");
        }
    }
}
