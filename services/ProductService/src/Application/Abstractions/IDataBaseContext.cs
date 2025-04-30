using Domain.Category;
using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions
{
    public interface IDataBaseContext
    {
        DbSet<Product> Products { get; }
        DbSet<Category> Categories { get; }

        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}