using static Domain.Models.CommonConstraints;

namespace API.Extensions
{
    public static class AddAuthorizationSettings
    {
        public static IServiceCollection AddAuthorizationSettingsService(this IServiceCollection services)
        {
            string admin = Enum.GetName(RoleVariants.Admin);
            string seller = Enum.GetName(RoleVariants.Seller);
            string customer = Enum.GetName(RoleVariants.Customer);

            services.AddAuthorization(options =>
            {
                options.AddPolicy(admin, policy =>
                    policy.RequireRole(admin));
                options.AddPolicy(seller, policy =>
                    policy.RequireRole(admin, seller));
                options.AddPolicy(customer, policy =>
                    policy.RequireRole(admin, customer));
            });

            return services;
        }
    }
}