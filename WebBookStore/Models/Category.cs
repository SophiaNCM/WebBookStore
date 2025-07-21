using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBookStore.Models
{
    [Table("Tbl_Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "É necessario colocar um nome")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Minimo: 10 | Maximo: 150")]
        public required string CategoryName { get; set; }

        public List<Books> Books { get; set; }
    }
}
