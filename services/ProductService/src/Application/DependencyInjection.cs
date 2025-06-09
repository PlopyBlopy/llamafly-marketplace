using Application.Products.Create;
using Domain.Commands.Products.Create;
using FluentValidation;
using MediatoR.Alternative.Lite;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatoR();
            services.AddValidators();

            return services;
        }

        private static IServiceCollection AddMediatoR(this IServiceCollection services)
        {
            services.AddMediatorAlt();

            //services.AddMediatorAlt(
            //    typeof(Application.Products.Create.CreateProductCommandHandler).Assembly,
            //    typeof(Domain.Commands.Products.Create.CreateProductCommand).Assembly);

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