using System.ComponentModel.DataAnnotations;

namespace ControlePagamentoEntidades.Models
{
    public class PagamentoModel
    {
        [Key]
        public int PagamentoID { get; set; }

        [Required]
        public int PagamentoSeq { get; set; }

        [Required]
        public DateTime PagamentoData { get; set; }

        [Required]
        public double PagamentoValor { get; set; }  

        public ProcessoModel ProcessoModel { get; set; }

    }
}
