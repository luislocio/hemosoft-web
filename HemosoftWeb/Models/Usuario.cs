using HemoSoft.Models.Enum;

namespace HemoSoft.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NomeDeUsuario { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}