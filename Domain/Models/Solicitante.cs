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

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Responsavel { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Senha { get; set; }

        public StatusUsuario StatusUsuario { get; set; }
        public List<Solicitacao> Solicitacoes { get; set; }
    }
}