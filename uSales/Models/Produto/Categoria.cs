using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uSales.Models.Produto
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(15)]
        [Required(ErrorMessage = "Digite uma descrição para a categoria.")]
        public string Descricao { get; set; }
    }
}
