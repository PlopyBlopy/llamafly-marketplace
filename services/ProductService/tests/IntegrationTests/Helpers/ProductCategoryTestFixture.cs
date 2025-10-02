using IntegrationTests.Abstractions;
using Xunit;

namespace IntegrationTests.Helpers
{
    public class ProductCategoryTestFixture : IAsyncLifetime
    {
        private readonly FunctionalTestWebAppFactory _factory;
        public HttpClient HttpClient { get; private set; }
        public TestProductDataHelper TestProductData { get; private set; }
        public TestCategoryDataHelper TestCategoryData { get; private set; }

        public ProductCategoryTestFixture()
        {
            _factory = new FunctionalTestWebAppFactory();
        }

        public async Task InitializeAsync()
        {
            await _factory.InitializeAsync();
            HttpClient = _factory.CreateClient();
            TestProductData = new TestProductDataHelper(HttpClient);
            TestCategoryData = new TestCategoryDataHelper(HttpClient);
        }

        public async Task DisposeAsync()
        {
            HttpClient?.Dispose();
            await _factory.DisposeAsync();
        }
    }
}