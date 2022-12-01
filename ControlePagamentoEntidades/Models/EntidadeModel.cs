using System.ComponentModel.DataAnnotations;

namespace ControlePagamentoEntidades.Models
{
    public class EntidadeModel
    {
        [Key]
        public int EntidadeID { get; set; }

        [Required (ErrorMessage = "Teste")]
        public string EntidadeNome { get; set; }

        [Required (ErrorMessage = "Teste1")]
        public string EntidadeCNPJ { get; set; }
    }
}
