namespace Infrastructure.Abstractions
{
    public interface IDatabaseContext
    {
        //DbSet<Model> Products { get; }

        Task<int> SaveChangesAsync(CancellationToken ct = default);

        void Detach<TEntity>(TEntity entity) where TEntity : class;
    }
}