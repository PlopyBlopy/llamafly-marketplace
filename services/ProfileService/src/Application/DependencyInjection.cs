using MediatoR.Alternative.Lite;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatoR();

            return services;
        }

        private static IServiceCollection AddMediatoR(this IServiceCollection services)
        {
            services.AddMediatorAlt();

            services.AddMediatorAltFluentValidation();
            return services;
        }
    }
}