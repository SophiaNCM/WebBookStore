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
   



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBooksRepository Tblbooks)
        {
            _logger = logger;

            _Books = Tblbooks;
    
        }

        public IActionResult Index()
        {
            IEnumerable<Books> books;
            books = _Books.Books;
            var BooksViewModel = new BookViewModel { Books = books };
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
