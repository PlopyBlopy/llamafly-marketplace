using Domain.Interfaces.Services;
using Infrastructure.Abstractions;
using Infrastructure.Database.Context;
using Infrastructure.Extensions;
using Infrastructure.HttpServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataBaseContext(configuration);
            services.AddHttpClients(configuration);
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

        private static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();

            string? profileServiceUri = configuration.GetConnectionString(Services.PROFILE_SERVICE);

            if (!string.IsNullOrEmpty(profileServiceUri))
            {
                services.AddHttpClient(Services.PROFILE_SERVICE, (client) =>
                {
                    client.BaseAddress = new Uri(profileServiceUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                });
            }

            services.AddScoped<IProfileService, ProfileService>();

            return services;
        }

        private static IServiceCollection AddExtensions(this IServiceCollection services)
        {
            return services;
        }
    }
}