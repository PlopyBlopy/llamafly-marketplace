using Microsoft.Extensions.DependencyInjection;
using Shared.Mapper.Profiles;

namespace Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddMapper();

            return services;
        }

        private static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(ProductProfile));

            return services;
        }
    }
}