using Microsoft.AspNetCore.Mvc;
using WebBookStore.Models;
using WebBookStore.Repositories.Interfaces;
using WebBookStore.ViewModel;

namespace WebBookStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBooksRepository _booksRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController (IBooksRepository booksRepository, ShoppingCart shoppingCart)
        {
            _booksRepository = booksRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var itens = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.shoppingCartItems = itens;
            var ShoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetCartTotal(),
            };
            return View(ShoppingCartViewModel);
        }
        public RedirectToActionResult AddItemShoppingCart(int bookId)
        {
            var BookSelect = _booksRepository.Books.FirstOrDefault(p => p.BookId == bookId);

            if (BookSelect != null)
            {
                _shoppingCart.AddItem(BookSelect);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveItemShoppingCart(int bookId)
        {
            var BookSelect = _booksRepository.Books.FirstOrDefault(p => p.BookId == bookId);

            if (BookSelect != null)
            {
                _shoppingCart.RemoveItem(BookSelect);
            }
            return RedirectToAction("Index");
        }
    }
}
