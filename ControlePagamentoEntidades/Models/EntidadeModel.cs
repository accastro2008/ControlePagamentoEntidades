using System.ComponentModel.DataAnnotations;

namespace ControlePagamentoEntidades.Models
{
    public class EntidadeModel
    {
        [Key]
        public int EntidadeID { get; set; }

        [Required (ErrorMessage = "{}")]
        public string? EntidadeNome { get; set; }

        [Required(ErrorMessage = "{}")]
        public string? EntidadeCNPJ { get; set; }
    }
}
