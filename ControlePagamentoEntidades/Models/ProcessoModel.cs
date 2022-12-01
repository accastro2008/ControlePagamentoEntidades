using System.ComponentModel.DataAnnotations;

namespace ControlePagamentoEntidades.Models
{
    public class ProcessoModel
    {
        [Key]
        public int ProcessoID { get; set; }


        [Required(ErrorMessage = "Teste")]
        public string ProcessoNumero { get; set; }


        [Required(ErrorMessage = "Teste")]
        public double ProcessoValorTotal { get; set; }
        
        [Required(ErrorMessage = "Teste")]
        public string ProcessoSituacao { get; set; }

        public EntidadeModel EntidadeModel { get; set; }

    }
}
