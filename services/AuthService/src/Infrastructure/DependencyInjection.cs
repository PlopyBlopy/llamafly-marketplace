using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infrastructure.Abstractions;
using Infrastructure.Database.Context;
using Infrastructure.gRPCServices;
using Infrastructure.HttpServices;
using JuiceLlama.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataBaseContext(configuration);
            services.AddHttpClients(configuration);
            services.AddGrpcService(configuration);

            services.AddAssemblyTypes<IRepository>(Assembly.GetExecutingAssembly());
            services.AddScoped<IProfileService, ProfileGrpcService>();
            services.AddScoped<IProfileGrpcServiceAdapter, ProfileGrpcServiceAdapter>();

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

            return services;
        }

        private static IServiceCollection AddExtensions(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddGrpcService(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("ProfileService");

            services.AddGrpcClient<ProfileServiceGrpc.ProfileService.ProfileServiceClient>(options =>
            {
                options.Address = new Uri(connectionString);
            });

            return services;
        }
    }
}