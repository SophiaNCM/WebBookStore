using Microsoft.AspNetCore.Mvc;
using WebBookStore.Models;
using WebBookStore.ViewModel;


namespace WebBookStore.Components
{
    public class ShoppingCartResume : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartResume(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke ()
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
    }
}
