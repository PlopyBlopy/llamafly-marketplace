using Domain.Commands.Products.Create;
using Domain.Commands.Products.Update;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shared.Mapper.Profiles;
using Shared.Validation.Models;

namespace Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddMapper();
            services.AddValidators();

            return services;
        }

        private static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(ProductProfile));

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateProductCommand>, CreateProductCommandValidator>();
            services.AddTransient<IValidator<UpdateProductCommand>, UpdateProductCommandValidator>();

            return services;
        }
    }
}