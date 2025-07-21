using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebBookStore.Models;
using WebBookStore.Repositories;
using WebBookStore.Repositories.Interfaces;
using WebBookStore.ViewModel;
using static System.Reflection.Metadata.BlobBuilder;
namespace WebBookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksRepository _Books;
        private readonly IPublisherRepository _Publisher;
        private readonly ICategoryRepository _Category;


        public BooksController(IBooksRepository Tblbooks, IPublisherRepository Tblpublisher, ICategoryRepository TblCategory)
        {
            _Books = Tblbooks;
            _Publisher = Tblpublisher;
            _Category = TblCategory;
        }

        public IActionResult Index()
        {
            IEnumerable<Books> books;
            books = _Books.Books ;
            var BooksViewModel = new BookViewModel { Books = books };
            return View(BooksViewModel);
            
        }

        public IActionResult Details(int bookId)
        {
            var books = _Books.Books.FirstOrDefault(b => b.BookId == bookId);
            var categories = _Category.Categories.FirstOrDefault(C => C.CategoryId == books.CategoryId);
            var publishers = _Publisher.Publishers.FirstOrDefault(p => p.PublisherId == books.PublisherId) ;
            var BooksViewModel = new BookViewModel
            {
                BookDetail = books,
                Publishers = publishers,
                Categories = categories
                
            };
            
            return View(BooksViewModel);
        }
    }
}
