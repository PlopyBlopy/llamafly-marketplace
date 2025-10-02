using API.Endpoints;
using Domain.Commands.Products;
using System.Net.Http.Json;

namespace IntegrationTests.Helpers
{
    public sealed class TestProductDataHelper
    {
        private readonly HttpClient _httpClient;

        public TestProductDataHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Guid> CreateProductAsync(Guid categoryId)
        {
            var request = new CreateProductRequest("Test Title", "Test Description", 1000, categoryId, Guid.NewGuid());

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(Routes.CREATE_PRODUCT, request);

            var productId = await response.Content.ReadFromJsonAsync<Guid>();

            return productId;
        }
    }
}
