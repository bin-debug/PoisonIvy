using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PoisonIvy.IoC;
using Swashbuckle.AspNetCore.Swagger;

namespace PoisonIvy.CatalogApi
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

            string ASPNETCORE_ENVIRONMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string COUCHBASE_SERVER = Environment.GetEnvironmentVariable("COUCHBASE_SERVER");
            string COUCHBASE_USERNAME = Environment.GetEnvironmentVariable("COUCHBASE_USERNAME");
            string COUCHBASE_PASSWORD = Environment.GetEnvironmentVariable("COUCHBASE_PASSWORD");

            if (ASPNETCORE_ENVIRONMENT.ToLower() == "development")
                services.AddCouchbase(Configuration.GetSection("Couchbase"));
            else
            {
                services.AddCouchbase(client =>
                {
                    client.Servers = new List<Uri> { new Uri(COUCHBASE_SERVER) };
                    client.Username = COUCHBASE_USERNAME;
                    client.Password = COUCHBASE_PASSWORD;
                    client.UseSsl = false;
                });
            }

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Catalog Microservice", Version = "v1" });
            });

            services.AddMediatR(typeof(Startup));
            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog Microservice V1");
            });
        }
    }
}
