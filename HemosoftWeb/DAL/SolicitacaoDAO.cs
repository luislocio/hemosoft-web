using HemoSoft.Models;
using HemosoftWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HemosoftWeb.DAL
{
    public class SolicitacaoDAO
    {
        private readonly Context _context;
        public SolicitacaoDAO(Context context)
        {
            _context = context;
        }

        public void CadastrarSolicitacao(Solicitacao so)
        {
            _context.Solicitacoes.Add(so);
            _context.SaveChanges();
        }

        public List<Solicitacao> BuscarSolicitacoesPorSolicitante(Solicitacao s)
        {
            return _context.Solicitacoes
                .Include("Solicitante")
                .Include("Doacoes")
                .Where(x => x.Solicitante.IdSolicitante.Equals(s.Solicitante.IdSolicitante))
                .ToList();

        }

        public Solicitacao BuscarSolicitacaoPorId(Solicitacao s)
        {
            return _context.Solicitacoes
                .Include("Solicitante")
                .Include("Doacoes")
                .FirstOrDefault
                (x => x.IdSolicitacao.Equals(s.IdSolicitacao));
        }

        public List<Solicitacao> ListarSolicitacoes()
        {
            return _context.Solicitacoes
                .Include("Solicitante")
                .Include("Doacoes")
                .ToList();
        }
    }
}
