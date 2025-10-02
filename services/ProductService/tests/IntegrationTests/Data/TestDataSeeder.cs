using Bogus;
using Domain.Category;
using Domain.Product;
using Infrastructure.Database.Abstractions;

namespace IntegrationTests.Data
{
    public class TestDataSeeder
    {
        private readonly IDataBaseContext _context;
        private readonly Faker _faker;

        public readonly List<ProductModel> _products = new();
        public readonly List<CategoryModel> _categories = new();

        public TestDataSeeder(IDataBaseContext context)
        {
            _context = context;
            _faker = new Faker();
        }

        public async Task SeedAsync()
        {
            await SeedCategories();
            await SeedProducts();

            await _context.SaveChangesAsync();
        }

        public async Task SeedProducts()
        {
            if (_categories.Any())
            {
                var productFaker = new Faker<ProductModel>("ru")
                    .CustomInstantiator(f => new ProductModel(
                        f.Random.Guid(),
                        f.Commerce.ProductName(),
                        f.Commerce.ProductDescription(),
                        f.Random.Decimal(ProductConstraints.MIN_PRICE, ProductConstraints.MAX_PRICE),
                        f.Random.Double(0.0, 5.0),
                        f.Random.ListItem(_categories).Id,
                        f.Random.Guid(),
                        f.Date.Soon(7),
                        f.Date.Recent(7)
                    ));

                await AddProductRangeAsync(productFaker, 20);
            }
        }

        //TODO: наследовани одной категории от другой
        public async Task SeedCategories()
        {
            var categoryFaker = new Faker<CategoryModel>("ru")
                .CustomInstantiator(f => new CategoryModel(
                    f.Random.Guid(),
                    f.Commerce.Categories(3).Where(c => c.Length >= CategoryConstraints.MIN_TITLE_LENGTH).First(),
                    null,
                    f.Date.Soon(7),
                    f.Date.Recent(7)
                ));

            await AddCategoryRangeAsync(categoryFaker, 6);
        }

        private async Task AddProductRangeAsync(Faker<ProductModel> entity, int generateCount = default)
        {
            _products.AddRange(entity.Generate(generateCount));
            await _context.Products.AddRangeAsync(_products, CancellationToken.None);
        }

        private async Task AddCategoryRangeAsync(Faker<CategoryModel> entity, int generateCount = default)
        {
            _categories.AddRange(entity.Generate(generateCount));
            await _context.Categories.AddRangeAsync(_categories, CancellationToken.None);
        }
    }
}