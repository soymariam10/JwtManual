using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiJWTManual.Services;
using Aplicacion.UnitOfWork;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ApiJWTManual.Extensions
{
    // Extensión estática que contiene métodos de configuración de servicios de aplicación
    public static class ApplicationServiceExtension
    {
        // Configurar la política de CORS para permitir cualquier origen, método y encabezado
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });

        // Agregar servicios de aplicación al contenedor de dependencias
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Registrar servicios de usuario y unidad de trabajo como servicios scoped
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
