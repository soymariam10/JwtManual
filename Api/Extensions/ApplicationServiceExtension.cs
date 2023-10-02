using Aplicacion.UnitOfWork;
using Dominio.Interfaces;

namespace Api.Extensions;

    public static class ApplicationServiceExtension
    {

    public static void ConfigureCors(this IServiceCollection services) => 
    services.AddCors(Options =>
        {
            Options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
        });

    public static void AddAplicacionServices(this IServiceCollection services)
        {
            //services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();
            //services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IMapper, Mapper>();
        }
    }
