using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HemoSoft.Models
{
    [Table("ImpedimentosTemporarios")]
    public class ImpedimentosTemporarios
    {
        [Key] public int IdImpedimentosTemporarios { get; set; }
        public bool? BebidaAlcoolica { get; set; }
        public int? BebidaAlcoolicaUltimaVez { get; set; }
        public Gravidez? Gravidez { get; set; }
        public int? GravidezUltimaVez { get; set; }
        public bool? Gripe { get; set; }
        public int? GripeUltimaVez { get; set; }
        public bool? Tatuagem { get; set; }
        public int? TatuagemUltimaVez { get; set; }
        public Doacao Doacao { get; set; }
    }
}