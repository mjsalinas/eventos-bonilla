using EventosBonilla.EventosBonilla.Aplicacion.Servicios;
using EventosBonilla.EventosBonilla.Dominio;
using EventosBonilla.EventosBonilla.Dominio.Modelos;
using EventosBonilla.EventosBonilla.Infraestructura;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla
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
            services.AddDbContext<eventos_bonillaContext>(o =>
            {
                var connectionString = "server=localhost;port=3306;user=root;database=eventos_bonilla";
                o.UseMySql(connectionString);
            });
            services.AddTransient<ICategoriasRepositorio, CategoriasRepositorio>();
            services.AddTransient<ICategoriasAppService, CategoriasAppService>();

            services.AddTransient<IClientesRepositorio, ClientesRepositorio>();
            services.AddTransient<IEventosRepositorio, EventosRepositorio>();
            services.AddTransient<IMobiliarioRepositorio, MobiliarioRepositorio>();
            services.AddTransient<IReservacionRepositorio, ReservacionRepositorio>();
            services.AddTransient<IMobiliarioPorReservacionRepositorio, MobiliarioPorReservacionRepositorio>();
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
        }
    }
}
