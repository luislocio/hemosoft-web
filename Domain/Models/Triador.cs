using Domain.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Triadores")]
    public class Triador
    {
        [Key] public int IdTriador { get; set; }
        public string Matricula { get; set; }
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
        public StatusUsuario StatusUsuario { get; set; }
        public List<Doacao> Doacoes { get; set; }
    }
}