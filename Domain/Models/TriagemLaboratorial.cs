using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("TriagensLaboratoriais")]
    public class TriagemLaboratorial
    {
        [Key] public int IdTriagemLaboratorial { get; set; }
        public bool? HepatiteB { get; set; }
        public bool? HepatiteC { get; set; }
        public bool? Hiv { get; set; }
        public StatusTriagem? StatusTriagem { get; set; }
        public Doacao Doacao { get; set; }
    }
}