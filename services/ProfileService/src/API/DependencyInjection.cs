using API.Extensions;
using Infrastructure.gRPCServices;

namespace API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPI(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddgRPCService();
            services.AddScoped<IProfileGrpcServiceAdapter, ProfileGrpcServiceAdapter>();

            return services;
        }

        private static IServiceCollection AddgRPCService(this IServiceCollection services)
        {
            services.AddGrpc();

            return services;
        }
    }
}