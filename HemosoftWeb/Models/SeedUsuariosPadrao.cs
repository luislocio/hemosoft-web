using System.Collections.Generic;

namespace HemoSoft.Models
{
    public class SeedUsuariosPadrao : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            #region Seed Triadores
            IList<Triador> triadores = new List<Triador>();

            triadores.Add(new Triador()
            {
                Matricula = "1111111",
                NomeCompleto = "Triador 1",
                Senha = "senhatriador",
                StatusUsuario = StatusUsuario.Ativo
            });

            triadores.Add(new Triador()
            {
                Matricula = "1234567",
                NomeCompleto = "Triador 2",
                Senha = "senhatriador",
                StatusUsuario = StatusUsuario.Ativo
            });
            triadores.Add(new Triador()
            {
                Matricula = "3333333",
                NomeCompleto = "Triador 3",
                Senha = "senhatriador",
                StatusUsuario = StatusUsuario.Inativo
            });

            context.Triadores.AddRange(triadores);
            #endregion

            #region Seed Solicitantes
            IList<Solicitante> solicitantes = new List<Solicitante>();

            solicitantes.Add(new Solicitante
            {
                Cnpj = "11111111111111",
                RazaoSocial = "Solicitante 1",
                Responsavel = "Responsavel 1",
                Senha = "senhasolicitante",
                StatusUsuario = StatusUsuario.Ativo
            });

            solicitantes.Add(new Solicitante
            {
                Cnpj = "12345678901234",
                RazaoSocial = "Solicitante 2",
                Responsavel = "Responsavel 2",
                Senha = "senhasolicitante",
                StatusUsuario = StatusUsuario.Ativo
            });

            solicitantes.Add(new Solicitante
            {
                Cnpj = "33333333333333",
                RazaoSocial = "Solicitante 3",
                Responsavel = "Responsavel 3",
                Senha = "senhasolicitante",
                StatusUsuario = StatusUsuario.Inativo
            });
            #endregion

            context.Solicitantes.AddRange(solicitantes);

            base.Seed(context);
        }
    }
}
