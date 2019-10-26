using HemosoftWeb.Models.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HemosoftWeb.Models
{
    [Table("Doadores")]
    public class Doador
    {
        [Key] public int IdDoador { get; set; }
        public string Cpf { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public string NomeCompleto { get; set; }
        public Genero Genero { get; set; }
        public List<Doacao> Doacoes { get; set; }
        public FatorRh? FatorRh { get; set; }
        public TipoSanguineo? TipoSanguineo { get; set; }
    }
}