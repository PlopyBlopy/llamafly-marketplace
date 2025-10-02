using Infrastructure.Abstractions;
using IntegrationTests.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace IntegrationTests.Extensions
{
    /// <summary>
    /// Component Tests - tests with data base
    /// </summary>
    public class BaseIntegrationTest : IClassFixture<FunctionalTestWebAppFactory>, IDisposable
    {
        private readonly IServiceScope _scope;
        protected readonly IDatabaseContext DbContext;
        protected HttpClient HttpClient { get; init; }

        public BaseIntegrationTest(FunctionalTestWebAppFactory factory)
        {
            HttpClient = factory.CreateClient();

            _scope = factory.Services.CreateScope();

            DbContext = _scope.ServiceProvider.GetRequiredService<IDatabaseContext>();
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
        }
    }
}