using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimpseApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LimpseApi
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
            services.AddCors();
            services.AddScoped<TecnicosRepository>();
            services.AddScoped<ServiciosRepository>();
            services.AddScoped<MaterialesRepository>();
            services.AddScoped<KitsRepository>();
            services.AddScoped<ServiciosKitRepository>();
            services.AddScoped<MaterialesKitRepository>();
            services.AddScoped<UsuariosRepository>();
            services.AddScoped<LoginRepository>();
            services.AddScoped<CatalogosRepository>();
            services.AddScoped<ClientesRepository>();
            services.AddScoped<TelefonosClienteRepository>();
            services.AddScoped<DireccionesClienteRepository>();
            services.AddScoped<PreciosServiciosRepository>();
            services.AddScoped<PreciosMaterialesRepository>();

            services.AddControllers();
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

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").WithHeaders("*").WithMethods("*"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
