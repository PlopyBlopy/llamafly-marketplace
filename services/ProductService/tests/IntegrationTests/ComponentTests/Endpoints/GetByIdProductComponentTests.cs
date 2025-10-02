using API.Endpoints;
using FluentAssertions;
using IntegrationTests.Abstractions;
using IntegrationTests.FunctionalTests;
using System.Net;
using Xunit;

namespace IntegrationTests.ComponentTests.Endpoints
{
    public class GetByIdProductComponentTests : BaseIntegrationTest
    {
        public GetByIdProductComponentTests(FunctionalTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_ReturnProduct_FromActualDatabase()
        {
            // Arrange
            await DataSeeder.SeedAsync();

            var productId = DataSeeder._products[0].Id;

            // Act
            HttpResponseMessage response = await HttpClient.GetAsync(Routes.GetByIdProduct(productId));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Should_ReturnNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = Guid.NewGuid();

            // Act
            HttpResponseMessage response = await HttpClient.GetAsync(Routes.GetByIdProduct(productId));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}