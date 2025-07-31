using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBookStore.Models
{
    [Table("ShoppingCartItems")]
    public class ShoppingCartItem
    { 
        public int ShoppingCartItemId { get; set; }

        public Books Books { get; set; }

        public int Quantidade {  get; set; }

        [StringLength(200)]
        public string ShoppingCartId { get; set; }
    }
}
