using HemosoftWeb.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HemosoftWeb.Models
{
    [Table("Doacoes")]
    public class Doacao
    {
        [Key] public int IdDoacao { get; set; }
        public DateTime DataDoacao { get; set; }
        public StatusDoacao StatusDoacao { get; set; }
        public Doador Doador { get; set; }
        public Triador Triador { get; set; }
        public Solicitacao Solicitacao { get; set; }
        public int IdTriagemClinica { get; set; }
        public int IdTriagemLaboratorial { get; set; }
        public int IdImpedimentosTemporarios { get; set; }
        public int IdImpedimentosDefinitivos { get; set; }

        [ForeignKey("IdTriagemClinica")]
        public TriagemClinica TriagemClinica { get; set; }
        [ForeignKey("IdTriagemLaboratorial")]
        public TriagemLaboratorial TriagemLaboratorial { get; set; }
        [ForeignKey("IdImpedimentosTemporarios")]
        public ImpedimentosTemporarios ImpedimentosTemporarios { get; set; }
        [ForeignKey("IdImpedimentosDefinitivos")]
        public ImpedimentosDefinitivos ImpedimentosDefinitivos { get; set; }
    }
}