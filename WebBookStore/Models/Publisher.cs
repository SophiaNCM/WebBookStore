using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBookStore.Models
{
    [Table("Tbl_Publsiher")]
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "É necessario colocar um nome")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Minimo: 10 | Maximo: 200")]
        public required string PublisherName { get; set; }

        public List<Books> Books { get; set; }
    }
}
