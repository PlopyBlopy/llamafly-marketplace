using Infrastructure.Abstractions;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataBaseContext(configuration);
            services.AddRepositories();
            return services;
        }

        private static IServiceCollection AddDataBaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DataBase");

            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IDatabaseContext, DatabaseContext>(provider => provider.GetRequiredService<DatabaseContext>());

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            AddProductRepositories(services);
            AddCategoryRepositories(services);

            return services;
        }

        private static IServiceCollection AddProductRepositories(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddCategoryRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
}