using Domain.Commands;
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
                typeof(UserProfile),
                typeof(ProfileDtoProfile),
                typeof(RoleProfile),
                typeof(LoginProfile));

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            return services;
        }
    }
}