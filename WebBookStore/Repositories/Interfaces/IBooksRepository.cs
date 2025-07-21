using WebBookStore.Models;

namespace WebBookStore.Repositories.Interfaces
{
    public interface IBooksRepository
    {
        IEnumerable<Books> Books { get; }
        IEnumerable<Books> BooksPublisher { get; }

        Books GetBookById(int idBook);
    }
}
