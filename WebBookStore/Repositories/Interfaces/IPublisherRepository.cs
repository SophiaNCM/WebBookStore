using WebBookStore.Models;

namespace WebBookStore.Repositories.Interfaces
{
    public interface IPublisherRepository
    {
        IEnumerable<Publisher> Publishers { get; }
    }
}
