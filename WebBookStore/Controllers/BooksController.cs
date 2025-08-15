using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
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

        public IActionResult Index(string categoryName)
        {
            IEnumerable<Books> books;
            books = _Books.Books;
            string categoriaAtual = string.Empty;
            if (categoryName.IsNullOrEmpty())
            {
                books = _Books.Books.OrderBy(b => b.BookId);
                categoriaAtual = "Todos os livros";

            }
            else
            {
                books = _Books.Books.Where(b => b.Category.CategoryName.Equals(categoryName)).OrderBy(c => c.Category.CategoryName);
                categoriaAtual = categoryName;
            }
            var BooksViewModel = new BookViewModel { Books = books, categoryName = categoriaAtual };

            return View(BooksViewModel);

        }

        //todos os banners dos livros são links, quando voce clica, ele pega o id do livro selecionado e carrega a pagina dele 
        public IActionResult Details(int bookId)
        {
            //informando que o livro que queremos é o com o id do que clicamos
            var books = _Books.Books.FirstOrDefault(b => b.BookId == bookId);
            var categories = _Category.Categories.FirstOrDefault(C => C.CategoryId == books.CategoryId);
            var publishers = _Publisher.Publishers.FirstOrDefault(p => p.PublisherId == books.PublisherId);
            var BooksViewModel = new BookViewModel
            {
                BookDetail = books,
                Publishers = publishers,
                Categories = categories
            };

            return View(BooksViewModel);
        }

        //Essa é a action do input, por isso o nome precisa ser o mesmo, assim a action sabe qual info pegar 
        public ViewResult Search(string searchString)
        {
            //Enumerando os livros
            IEnumerable<Books> books;
           //se for nulo, mostra tudo
            if (string.IsNullOrEmpty(searchString))
            {
                books = _Books.Books.OrderBy(p => p.BookId);
         
            }
            else
            {
                //se nao é nulo mostra tudo
                books = _Books.Books.Where(p => p.Title.ToLower().Contains(searchString.ToLower()));
            }
            //a view returnada é a Index, pois é a que o nosso input esta e é a pagina que queremos
            return View("~/Views/Books/Index.cshtml", new BookViewModel
            {
                Books = books,
             
            });
        }

    }
}
