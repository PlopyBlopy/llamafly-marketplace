using Application.Abstractions;
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
            return services;
        }

        private static IServiceCollection AddDataBaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DataBase");

            services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IDataBaseContext>(provider => provider.GetRequiredService<DataBaseContext>());

            return services;
        }
    }
}