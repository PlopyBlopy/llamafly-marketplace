using Infrastructure.Database.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.PostgreSql;
using Xunit;

namespace IntegrationTests.Abstractions
{
    public class FunctionalTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .WithDatabase("testdb")
            .WithUsername("postgres")
            .WithPassword("postgres")
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<DataBaseContext>));

                services.AddDbContext<DataBaseContext>(options =>
                {
                    options.UseNpgsql(_dbContainer.GetConnectionString());
                });
            });
        }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();
            await InitializeDatabaseAsync();
        }

        public new async Task DisposeAsync()
        {
            await _dbContainer.StopAsync();
        }

        private async Task InitializeDatabaseAsync()
        {
            using var scope = Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
            await context.Database.MigrateAsync();
        }
    }
}