using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uSales.Models.Produto
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(6)]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Required]
        public decimal Custo { get; set; }
        [Required]
        [Display(Name = "Preço de Venda")]
        public decimal PrecoVenda { get; set; }
        [Display(Name = "Lucro %")]
        public float Lucro { get; set; }
        [MaxLength(500)]
        [Display(Name = "Observações")]
        public string Observacoes { get; set; }
        public string ImagemPath { get; set; }
        [ForeignKey("ID")]
        public virtual Categoria Categoria { get; set; }
        [ForeignKey("ID")]
        public virtual Medida Medida { get; set; }
    }
}
