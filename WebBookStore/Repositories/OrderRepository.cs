using WebBookStore.Context;
using WebBookStore.Models;
using WebBookStore.Repositories.Interfaces;

namespace WebBookStore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        //instancia para acessar o banco de dados
        private readonly AppDbContext _appDbContext;
        //instacia para acessar o carrinho de compra, ja que para obter o pedido precisamos dos itens do carrinho
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository (AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void AddOrder(Orders order)
        {
            // Com esses tres geramos um pedido, e meio que ja avisamos o banco de dados que ha um pedido e seu id
            order.ShippingDate = DateTime.Now;
            _appDbContext.Orders.Add(order);
            //salvando para 'gravar' no banco de dados
            _appDbContext.SaveChanges();

            //Agora chamamos os itens do carrinho
            var shoppingCartItens = _shoppingCart.shoppingCartItems;

            // vamos percorrer o carrinho e pegar os itens, assim vamos add eles no pedido
            foreach (var cartItens in shoppingCartItens) {
                //estamos colocando no orderDetails, porque ele guarda os detalhes dos itens e o Order guarda infos gerais do pedido 
                var OrderDetails = new OrderDetails()
                {

                    Quant = cartItens.Quantidade,
                    BooksId = cartItens.Books.BookId,
                    //Informando para qual Order essas infos vão
                    OrderId = order.OrderId,
                    Price = cartItens.Books.Price,
                };
                _appDbContext.OrderDetails.Add(OrderDetails); //salvando os itens

            }
            _appDbContext.SaveChanges ();// salvando o pedido e os itens | salvando todo esse processo feito
        }
    }
}
