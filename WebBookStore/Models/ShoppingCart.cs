using Microsoft.EntityFrameworkCore;
using WebBookStore.Context;
namespace WebBookStore.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _context;

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }
        public string ShoppingCartId { get; set; }  
        public List<ShoppingCartItem> shoppingCartItems{ get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            //define uma sessão 
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //obtem ou gera o Id do carrinho
            string CartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na sessão
            session.SetString("CartId", CartId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new ShoppingCart(context)
            {
                ShoppingCartId = CartId
            };
        }

        public void AddItem(Books book)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.Books.BookId == book.BookId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null) 
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Books = book,
                    Quantidade = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                
              shoppingCartItem.Quantidade++;

                
            }
            _context.SaveChanges();
        }
        public int RemoveItem(Books book) 
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.Books.BookId == book.BookId && s.ShoppingCartId == ShoppingCartId);

            var quantLocal = 0;

            if (shoppingCartItem != null) 
            { 
                if(shoppingCartItem.Quantidade > 1)
                {
                    shoppingCartItem.Quantidade--;
                    quantLocal = shoppingCartItem.Quantidade;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
            return quantLocal;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return shoppingCartItems ?? 
                (shoppingCartItems = _context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s=> s.Books).ToList());
        }
        public void CleanCart()
        {
            var CartItems = _context.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(CartItems);
            _context.SaveChanges();
        }

        public decimal GetCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Books.Price * c.Quantidade).Sum();

            return total;
        }
    }
}
