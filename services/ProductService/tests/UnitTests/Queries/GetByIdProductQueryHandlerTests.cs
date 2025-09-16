using Application.Queries.Products;
using AutoMapper;
using Domain.Interfaces.Repositories.Products;
using Domain.Product;
using Domain.Queries.Products;
using FluentResults;
using FluentResults.Errors;
using Moq;

namespace UnitTests.Queries
{
    public class GetByIdProductQueryHandlerTests
    {
        private readonly Mock<IGetByIdProductRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GetByIdProductQueryHandler _handler;

        public GetByIdProductQueryHandlerTests()
        {
            _mockRepository = new Mock<IGetByIdProductRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetByIdProductQueryHandler(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_GetByIdProduct_ReturnsProduct()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var query = new GetByIdProductQuery(productId);
            var expectedProductModel = new ProductModel(
                productId,
                "Test Title",
                "Test Description",
                1,
                1.0,
                Guid.NewGuid(),
                Guid.NewGuid(),
                DateTime.Now,
                DateTime.Now
            );

            _mockRepository.Setup(repo => repo.GetByIdAsync(query, CancellationToken.None))
                            .ReturnsAsync(Result.Ok(expectedProductModel));

            var expectedResponse = new GetByIdProductResponse(productId,
                "Test Title",
                "Test Description",
                1,
                1.0,
                DateTime.Now,
                DateTime.Now);

            _mockMapper.Setup(mapper => mapper.Map<GetByIdProductResponse>(expectedProductModel))
                        .Returns(expectedResponse);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);

            Assert.Equal(productId, result.Value.Id);
            Assert.Equal("Test Title", result.Value.Title);
            Assert.Equal("Test Description", result.Value.Description);
            Assert.Equal(1M, result.Value.Price);
            Assert.Equal(1.0D, result.Value.Rating);

            _mockRepository.Verify(repo => repo.GetByIdAsync(query, CancellationToken.None), Times.Once);

            _mockMapper.Verify(mapper => mapper.Map<GetByIdProductResponse>(expectedProductModel), Times.Once);
        }

        [Fact]
        public async Task Handle_ProductNotFound_ReturnsFail()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var query = new GetByIdProductQuery(productId);

            _mockRepository.Setup(repo => repo.GetByIdAsync(query, CancellationToken.None))
                            .ReturnsAsync(Result.Fail<ProductModel>(new NotFoundError("GetByIdProductQuery", "ProductModel")));

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsFailed);
            Assert.NotEmpty(result.Errors);
            Assert.Contains("The 'ProductModel' not found.", result.Errors[0].Message);

            _mockMapper.Verify(mapper => mapper.Map<GetByIdProductResponse>(It.IsAny<ProductModel>()), Times.Never);
        }
    }
}