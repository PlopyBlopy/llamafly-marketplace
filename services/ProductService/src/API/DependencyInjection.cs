using API.Extensions;
using Microsoft.Extensions.Caching.Hybrid;

namespace API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
            services.AddHybridCache(configuration);

            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }

        public static IServiceCollection AddHybridCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
                //options.InstanceName = configuration["RedisCacheOptions:InstanceName"];
            });
            services.AddHybridCache(options =>
            {
                options.DefaultEntryOptions = new HybridCacheEntryOptions
                {
                    Expiration = TimeSpan.FromMinutes(10),
                    LocalCacheExpiration = TimeSpan.FromMinutes(5)
                };
            });

            return services;
        }
    }
}