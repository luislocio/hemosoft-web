using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HemoSoft.Models
{
    [Table("ImpedimentosDefinitivos")]
    public class ImpedimentosDefinitivos
    {
        [Key] public int IdImpedimentosDefinitivos { get; set; }
        public bool? AntecedenteAvc { get; set; }
        public bool? HepatiteB { get; set; }
        public bool? HepatiteC { get; set; }
        public bool? Hiv { get; set; }
        public Doacao Doacao { get; set; }
    }
}