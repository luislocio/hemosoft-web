using HemoSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HemoSoft.DAL
{
    class SolicitacaoDAO
    {

        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarSolicitacao(Solicitacao so)
        {
            ctx.Solicitacoes.Add(so);
            ctx.SaveChanges();
        }

        public static List<Solicitacao> BuscarSolicitacoesPorSolicitante(Solicitacao s)
        {
            return ctx.Solicitacoes
                .Include("Solicitante")
                .Include("Doacoes")
                .Where(x => x.Solicitante.IdSolicitante.Equals(s.Solicitante.IdSolicitante))
                .ToList();

        }

        public static Solicitacao BuscarSolicitacaoPorId(Solicitacao s)
        {
            return ctx.Solicitacoes
                .Include("Solicitante")
                .Include("Doacoes")
                .FirstOrDefault
                (x => x.IdSolicitacao.Equals(s.IdSolicitacao));
        }

        public static List<Solicitacao> ListarSolicitacoes()
        {
            return ctx.Solicitacoes
                .Include("Solicitante")
                .Include("Doacoes")
                .ToList();
        }
    }
}
