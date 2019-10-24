using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HemoSoft.Models
{
    [Table("Solicitacoes")]
    public class Solicitacao
    {
        [Key] public int IdSolicitacao { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public List<Doacao> Doacoes { get; set; }
        public Solicitante Solicitante { get; set; }
    }
}