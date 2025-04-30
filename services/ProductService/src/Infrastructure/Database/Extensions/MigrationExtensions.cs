using Infrastructure.Database.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Database.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var dbContext = services.GetRequiredService<DataBaseContext>();
                    dbContext.Database.Migrate(); // Применяет все ожидающие миграции
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<DataBaseContext>>();
                    logger.LogCritical(ex, "FATAL: Database migration failed");
                    throw; // Останавливаем приложение
                }
            }
        }
    }
}

//using IServiceScope scope = app.ApplicationServices.CreateScope();

//using DataBaseContext dbContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();

//dbContext.Database.Migrate();