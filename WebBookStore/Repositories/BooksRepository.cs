using Microsoft.EntityFrameworkCore;
using WebBookStore.Context;
using WebBookStore.Models;
using WebBookStore.Repositories.Interfaces;

namespace WebBookStore.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AppDbContext _context;

        public BooksRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Books> Books => _context.Books.Include(c => c.Category);
        public IEnumerable<Books> BooksPublisher => _context.Books.Include(p => p.Publisher);

        public Books GetBookById(int idBook)
        {
            return _context.Books.FirstOrDefault(b => b.BookId == idBook);
        }
    }
}
