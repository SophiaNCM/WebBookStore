using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebBookStore.Models;
using WebBookStore.Repositories.Interfaces;
using WebBookStore.ViewModel;

namespace WebBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBooksRepository _Books;
        private readonly ICategoryRepository _Category;



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBooksRepository Tblbooks, ICategoryRepository Tblcategory)
        {
            _logger = logger;

            _Books = Tblbooks;
            _Category = Tblcategory;
        }

        public IActionResult Index()
        {
            var categories = _Category.Categories.FirstOrDefault(C => C.CategoryId == 1);
            var books = _Books.Books.FirstOrDefault(b => b.CategoryId == categories.CategoryId);
            var BooksViewModel = new BookViewModel { BookDetail = books, Categories = categories };
            return View(BooksViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
