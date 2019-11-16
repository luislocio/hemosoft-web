using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("TriagensLaboratoriais")]
    public class TriagemLaboratorial
    {
        [Key] public int IdTriagemLaboratorial { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public bool? HepatiteB { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public bool? HepatiteC { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public bool? Hiv { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public StatusTriagem? StatusTriagem { get; set; }

        public Doacao Doacao { get; set; }
    }
}