using Microsoft.Extensions.DependencyInjection;

namespace Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddMapper();
            services.AddValidators();

            return services;
        }

        private static IServiceCollection AddMapper(this IServiceCollection services)
        {
            //services.AddAutoMapper(
            //    typeof(ModelProfile));

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            return services;
        }
    }
}