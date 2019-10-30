using Domain.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Solicitantes")]
    public class Solicitante
    {
        [Key] public int IdSolicitante { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Responsavel { get; set; }
        public string Senha { get; set; }
        public StatusUsuario StatusUsuario { get; set; }
        public List<Solicitacao> Solicitacoes { get; set; }
    }
}