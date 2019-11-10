using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("ImpedimentosTemporarios")]
    public class ImpedimentosTemporarios
    {
        [Key] public int IdImpedimentosTemporarios { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public bool? BebidaAlcoolica { get; set; }
        public int? BebidaAlcoolicaUltimaVez { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public Gravidez? Gravidez { get; set; }
        public int? GravidezUltimaVez { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public bool? Gripe { get; set; }
        public int? GripeUltimaVez { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public bool? Tatuagem { get; set; }
        public int? TatuagemUltimaVez { get; set; }

        public Doacao Doacao { get; set; }
    }
}