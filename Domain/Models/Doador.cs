using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Doadores")]
    public class Doador
    {
        // TODO: [ATRIBUTO] 1 - Adicionar atributo no Model.
        // TODO: [ATRIBUTO] 2 - Executar {add-migration "mensagemDaMigration" -Project:Repository}.
        // TODO: [ATRIBUTO] 3 - Executar {update-database -Project:Repository}.
        [Key] public int IdDoador { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public EstadoCivil? EstadoCivil { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public Genero? Genero { get; set; }

        public TipoSanguineo? TipoSanguineo { get; set; }

        public FatorRh? FatorRh { get; set; }

        public DateTime UltimaDoacao { get; set; }

        public List<Doacao> Doacoes { get; set; }
    }
}