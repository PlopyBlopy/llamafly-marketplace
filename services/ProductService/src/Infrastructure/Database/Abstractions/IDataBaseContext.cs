using Domain.Category;
using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Abstractions
{
    public interface IDataBaseContext
    {
        DbSet<ProductModel> Products { get; }
        DbSet<CategoryModel> Categories { get; }

        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
