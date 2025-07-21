namespace WebBookStore.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Models.Category> Categories { get; }
    }
}
