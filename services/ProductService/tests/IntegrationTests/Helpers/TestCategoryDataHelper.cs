using API.Endpoints;
using Domain.Commands.Categories;
using System.Net.Http.Json;

namespace IntegrationTests.Helpers
{
    public sealed class TestCategoryDataHelper
    {
        private readonly HttpClient _httpClient;

        public TestCategoryDataHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Guid> CreateCategoryAsync()
        {
            var request = new CreateCategoryRequest("Test Category", null);

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(Routes.CREATE_CATEGORY, request);

            var contentString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(contentString); // Посмотрим, что пришло
            var categoryId = await response.Content.ReadFromJsonAsync<Guid>();

            return categoryId;
        }
    }
}
