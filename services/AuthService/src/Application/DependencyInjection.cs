using Application.Extensions;
using Application.Extensions.JwtToken;
using Domain.Interfaces;
using MediatoR.Alternative.Lite;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatoR();
            services.AddExtensions();
            return services;
        }

        private static IServiceCollection AddMediatoR(this IServiceCollection services)
        {
            services.AddMediatorAlt();

            services.AddMediatorAltFluentValidation();
            return services;
        }

        private static IServiceCollection AddExtensions(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAccessToken, AccessToken>();
            services.AddScoped<IRefreshToken, RefreshToken>();
            return services;
        }
    }
}