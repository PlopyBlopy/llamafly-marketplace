using API.Endpoints;
using Domain.Queries.Products;
using FluentAssertions;
using IntegrationTests.Helpers;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace IntegrationTests.FunctionalTests.Endpoints
{
    public class GetByIdProductFunctionalTests : IClassFixture<ProductCategoryTestFixture>
    {
        private readonly ProductCategoryTestFixture _fixture;

        public GetByIdProductFunctionalTests(ProductCategoryTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Should_ReturnOk_And_Product_WhenProductDoesExist()
        {
            // Arrange
            var categoryId = await _fixture.TestCategoryData.CreateCategoryAsync();
            var productId = await _fixture.TestProductData.CreateProductAsync(categoryId);

            // Act
            HttpResponseMessage response = await _fixture.HttpClient.GetAsync(Routes.GetByIdProduct(productId));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseContent = await response.Content.ReadFromJsonAsync<GetByIdProductResponse>();

            Assert.Equal(responseContent.Id, productId);
        }

        [Fact]
        public async Task Should_ReturnNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = Guid.NewGuid();

            // Act
            HttpResponseMessage response = await _fixture.HttpClient.GetAsync(Routes.GetByIdProduct(productId));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}