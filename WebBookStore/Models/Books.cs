using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebBookStore.Models
{
    [Table("Tbl_Book")]
    public class Books
    {

        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Digite um titulo")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Minimo: 10 | Maximo: 300")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Digite uma descricao")]
        [StringLength(1500, MinimumLength = 300, ErrorMessage = "Minimo: 10 | Maximo: 1500")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Digite um preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.999, ErrorMessage = "O preço deve estar entre 1 e 999,999")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Digite um numero de paginas")]
        public int NumPage { get; set; }

        [StringLength(200, MinimumLength = 10, ErrorMessage = "Minimo: 10 | Maximo: 200")]
        public string? Cover { get; set; }

        [Required(ErrorMessage = "Digite um escritor")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Minimo: 10 | Maximo: 50")]
        public string Writer { get; set; }

        [Required(ErrorMessage = "Digite o idioma")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "Minimo: 10 | Maximo: 30")]
        public required string Language { get; set; }

        [Required(ErrorMessage = "Digite o pais de origem")]
        [MaxLength(3)]
        public char Country { get; set; }

        [Required(ErrorMessage = "Digite a data de lançamento")]
        public DateTime Release { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int PublisherId { get; set; }
        public virtual Publisher Publisher{ get; set; }

    }
}
