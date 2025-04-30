using Application.Products.Create;
using FluentValidation;
using MediatoR.Alternative.Lite;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidators();

            services.AddMediatorAlt();
            services.AddMediatorAltFluentValidation();

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateProductCommand>, CreateProductCommandValidator>();

            return services;
        }
    }
}