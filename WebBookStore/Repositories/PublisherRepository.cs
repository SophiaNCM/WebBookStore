using WebBookStore.Context;
using WebBookStore.Models;
using WebBookStore.Repositories.Interfaces;

namespace WebBookStore.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly AppDbContext _context;
        public PublisherRepository(AppDbContext context)
        { _context = context; }
        public IEnumerable<Publisher> Publishers => _context.Publishers;
    }
}
