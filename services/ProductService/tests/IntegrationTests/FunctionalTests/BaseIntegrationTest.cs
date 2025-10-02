using Infrastructure.Database.Abstractions;
using IntegrationTests.Abstractions;
using IntegrationTests.Data;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace IntegrationTests.FunctionalTests
{
    public class BaseIntegrationTest : IClassFixture<FunctionalTestWebAppFactory>, IDisposable
    {
        private readonly IServiceScope _scope;
        protected readonly IDataBaseContext DbContext;
        protected readonly TestDataSeeder DataSeeder;
        protected HttpClient HttpClient { get; init; }

        public BaseIntegrationTest(FunctionalTestWebAppFactory factory)
        {
            HttpClient = factory.CreateClient();

            _scope = factory.Services.CreateScope();

            DbContext = _scope.ServiceProvider.GetRequiredService<IDataBaseContext>();

            if (DbContext is not null)
                DataSeeder = new TestDataSeeder(DbContext);
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
        }
    }
}