using Domain.Interfaces.Repositories.Categories;
using Domain.Interfaces.Repositories.Products;
using Infrastructure.Database.Abstractions;
using Infrastructure.Database.Context;
using Infrastructure.Database.Repositories.Commands.Categories;
using Infrastructure.Database.Repositories.Commands.Products;
using Infrastructure.Database.Repositories.Queries.Categories;
using Infrastructure.Database.Repositories.Queries.Products;
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
            AddProductRepositories(services);
            AddCategoryRepositories(services);

            return services;
        }

        private static IServiceCollection AddProductRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICreateProductRepository, CreateProductRepository>();
            services.AddScoped<IUpdateProductRepository, UpdateProductRepository>();
            services.AddScoped<IRemoveProductRepository, RemoveProductRepository>();

            services.AddScoped<IGetByIdProductRepository, GetByIdProductRepository>();
            services.AddScoped<IGetAllProductRepository, GetAllProductRepository>();
            services.AddScoped<IGetAllProductsCardsRepository, GetAllProductsCardsRepository>();
            services.AddScoped<IGetAllProductsCardsFilteredRepository, GetAllProductsCardsFilteredRepository>();

            return services;
        }

        private static IServiceCollection AddCategoryRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICreateCategoryRepository, CreateCategoryRepository>();
            services.AddScoped<ICreateCategoriesRangeRepository, CreateCategoriesRangeRepository>();

            services.AddScoped<ICategoryExistRepository, CategoryExistRepository>();
            services.AddScoped<IGetByIdCategoryRepository, GetByIdCategoryRepository>();
            services.AddScoped<IGetAllCategoriesRepository, GetAllCategoriesRepository>();
            services.AddScoped<IGetAllCategoriesMinRepository, GetAllCategoriesMinRepository>();

            return services;
        }
    }
}