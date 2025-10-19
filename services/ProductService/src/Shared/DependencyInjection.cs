using Domain.Commands.Categories;
using Domain.Commands.Products;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shared.Helpers;
using Shared.Mapper.Profiles;
using Shared.Validation.Models.Category;
using Shared.Validation.Models.Product;

namespace Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddMapper();
            services.AddValidators();

            services.AddTransient<CategoriesHierarchyFormatter>();

            return services;
        }

        private static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(ProductProfile),
                typeof(CategoryProfile));

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateProductCommand>, CreateProductValidator>();
            services.AddTransient<IValidator<UpdateProductCommand>, UpdateProductValidator>();

            //services.AddTransient<IValidator<CreateCategoriesRangeCommand>, CreateCategoriesRangeValidator>();
            services.AddTransient<IValidator<CreateCategoryCommand>, CreateCategoryValidator>();

            return services;
        }
    }
}