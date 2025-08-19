using Microsoft.AspNetCore.Mvc;
using WebBookStore.Models;
using WebBookStore.Repositories.Interfaces;

namespace WebBookStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }


        [HttpGet]
        public IActionResult Checkout() // Aqui é basicamente o get, a View faz o trabalho do GET
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Orders order) 
        {
            int OrderItensTotal = 0;
            decimal OrderTotal = 0.0m;

            //obter os intes do carrinho 
            List<ShoppingCartItem> Items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.shoppingCartItems = Items;

            //verifica se existe itens 
            if(_shoppingCart.shoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho esta vazio");
            }

            //calcula o total de itens e o total do pedido
            foreach (var item in Items) 
            {
                OrderItensTotal += item.Quantidade;
                OrderTotal += (item.Books.Price * item.Quantidade);

            }

            //atribui os valores obtidos ao pedido
            order.TotalOrderItens = OrderItensTotal;
            order.TotalOrder = OrderTotal;

            //valida os dados do pedido
            if (ModelState.IsValid)
            {
                // cria o pedido e os detalhes
                _orderRepository.AddOrder(order);

                // define mensagens ao cluebte

                ViewBag.CheckoutCompleteMenssage = "Obrigado pelo seu pedido";
                ViewBag.OrderTotal = _shoppingCart.GetCartTotal();

                //limpa o carrinho do cliente
                _shoppingCart.CleanCart();

                //exibe a view com dados do cliente e do pedido
                return View("~/Views/Orders/CheckoutComplete.cshtml", order);
                 
            }
            return View(order);
        }
    }
}
