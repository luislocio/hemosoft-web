using HemosoftWeb.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HemosoftWeb.Models
{
    [Table("TriagensClinicas")]
    public class TriagemClinica
    {
        [Key] public int IdTriagemClinica { get; set; }
        public double Peso { get; set; }
        public int Pulso { get; set; }
        public StatusTriagem StatusTriagem { get; set; }
        public double Temperatura { get; set; }
        public Doacao Doacao { get; set; }
    }
}