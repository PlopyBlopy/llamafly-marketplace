using Domain.Interfaces.Repositories;
using Infrastructure.Database.Abstractions;
using Infrastructure.Database.Context;
using Infrastructure.Database.Repositories.Products.Commands;
using Infrastructure.Database.Repositories.Products.Queries;
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

            services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IDataBaseContext, DataBaseContext>(provider => provider.GetRequiredService<DataBaseContext>());

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICreateProductRepository, CreateProductRepository>();
            services.AddScoped<IUpdateProductRepository, UpdateProductRepository>();
            services.AddScoped<IRemoveProductRepository, RemoveProductRepository>();

            services.AddScoped<IGetByIdProductRepository, GetByIdProductRepository>();
            services.AddScoped<IGetAllProductRepository, GetAllProductRepository>();

            return services;
        }
    }
}