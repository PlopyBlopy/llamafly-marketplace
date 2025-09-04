namespace Domain.Interfaces.Repositories.Categories
{
    public interface ICategoryExistRepository
    {
        Task<bool> IsExistAsync(Guid categoryId, CancellationToken ct);
    }
}