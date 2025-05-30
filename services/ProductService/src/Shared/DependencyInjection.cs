using Microsoft.Extensions.DependencyInjection;
using Shared.Mappings.Profiles;

namespace Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(ProductProfile));

            return services;
        }
    }
}