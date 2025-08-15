using System.ComponentModel.DataAnnotations.Schema;

namespace WebBookStore.Models
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int BooksId { get; set; }
        public int Quant { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public virtual Books book { get; set; }
        public virtual Orders Order { get; set; }
    }
}
