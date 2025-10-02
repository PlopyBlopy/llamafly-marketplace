using IntegrationTests.Abstractions;
using Xunit;

namespace IntegrationTests.FunctionalTests
{
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