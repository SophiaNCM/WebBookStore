using WebBookStore.Context;
using WebBookStore.Models;
using WebBookStore.Repositories.Interfaces;

namespace WebBookStore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        { _context = context; }
        public IEnumerable<Category> Categories => _context.Categories;
    }
}
