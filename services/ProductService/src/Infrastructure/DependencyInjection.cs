using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infrastructure.Cache;
using Infrastructure.Database.Abstractions;
using Infrastructure.Database.Context;
using JuiceLlama.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Decorators.Сaches;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataBaseContext(configuration);
            services.AddScoped<ICacheService, CacheService>();

            services.AddAssemblyTypes<IRepository>(Assembly.GetExecutingAssembly());
            services.AddAssemblyDecoratorTypes<ICacheDecorator, IRepository>(typeof(ICacheDecorator).Assembly);

            return services;
        }

        private static IServiceCollection AddDataBaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DataBase");

            services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IDataBaseContext, DataBaseContext>(provider => provider.GetRequiredService<DataBaseContext>());

            return services;
        }
    }
}