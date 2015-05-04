using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uSales.Models.Produto
{
    [Table("Medida")]
    public class Medida
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(15)]
        [Required(ErrorMessage = "Digite uma descrição para a medida.")]
        public string Descricao { get; set; }
    }
}
