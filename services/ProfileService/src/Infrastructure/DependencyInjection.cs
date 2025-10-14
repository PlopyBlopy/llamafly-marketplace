using Domain.Interfaces.Repositories;
using Infrastructure.Abstractions;
using Infrastructure.Database.Context;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataBaseContext(configuration);
            services.AddAssemblyTypes<IRepository>(Assembly.GetExecutingAssembly());
            return services;
        }

        private static IServiceCollection AddDataBaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DataBase");

            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IDatabaseContext, DatabaseContext>(provider => provider.GetRequiredService<DatabaseContext>());

            return services;
        }
    }
}