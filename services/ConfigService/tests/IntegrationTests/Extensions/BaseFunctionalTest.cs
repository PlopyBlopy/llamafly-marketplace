using IntegrationTests.Abstractions;
using Xunit;

namespace IntegrationTests.Extensions
{
    /// <summary>
    /// Functional Tests - tests without data base
    /// </summary>
    public class BaseFunctionalTest : IClassFixture<FunctionalTestWebAppFactory>, IDisposable
    {
        protected HttpClient HttpClient { get; init; }

        public BaseFunctionalTest(FunctionalTestWebAppFactory factory)
        {
            HttpClient = factory.CreateClient();
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
        }
    }
}