using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("TriagensClinicas")]
    public class TriagemClinica
    {
        [Key] public int IdTriagemClinica { get; set; }

        [Range(50, 600, ErrorMessage = "Doador deve ter mais de 50kg.")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public double? Peso { get; set; }

        [Range(60, 100, ErrorMessage = "Doador deve estar com batimentos entre 60bpm e 100bpm.")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public int? Pulso { get; set; }

        [Range(36.1, 37.2, ErrorMessage = "Doador deve estar com temperatura entre 36,1°C e 37,2°C.")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public double? Temperatura { get; set; }

        public StatusTriagem StatusTriagem { get; set; }
        public Doacao Doacao { get; set; }
    }
}