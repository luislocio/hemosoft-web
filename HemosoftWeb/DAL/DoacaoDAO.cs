using HemosoftWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HemosoftWeb.DAL
{
    public class DoacaoDAO
    {
        private readonly Context _context;
        public DoacaoDAO(Context context)
        {
            _context = context;
        }

        public void CadastrarDoacao(Doacao d)
        {
            _context.Doacoes.Add(d);
            _context.SaveChanges();
        }

        public Doacao BuscarUltimaDoacaoPorDoador(Doador d)
        {
            //Where: é método que retorna todas as
            //ocorrências em uma busca
            return _context.Doacoes
                .Include("Doador")
                .Include("TriagemClinica")
                .Include("TriagemLaboratorial")
                .Include("ImpedimentosTemporarios")
                .Include("ImpedimentosDefinitivos")
                .OrderByDescending(x => x.DataDoacao)
                .FirstOrDefault(x => x.Doador.IdDoador.Equals(d.IdDoador));
        }

        public bool VerificarDoacoesPorStatusTriagemLaboratorial(TriagemLaboratorial t)
        {
            return _context.Doacoes.Any(x => x.TriagemLaboratorial.StatusTriagem == t.StatusTriagem);
        }

        public Doacao BuscarDoacaoPorId(Doacao d)
        {
            //Where: é método que retorna todas as
            //ocorrências em uma busca
            return _context.Doacoes
                .Include("Doador")
                .Include("TriagemClinica")
                .Include("TriagemLaboratorial")
                .Include("ImpedimentosTemporarios")
                .Include("ImpedimentosDefinitivos")
                .FirstOrDefault(x => x.IdDoacao.Equals(d.IdDoacao));
        }

        public List<Doacao> BuscarDoacaoPorStatus(Doacao d)
        {
            //Where: é método que retorna todas as
            //ocorrências em uma busca
            return _context.Doacoes
                .Include("Doador")
                .Include("TriagemClinica")
                .Include("TriagemLaboratorial")
                .Include("ImpedimentosTemporarios")
                .Include("ImpedimentosDefinitivos")
                .Where(x => x.StatusDoacao == d.StatusDoacao).ToList();
        }

        public void AlterarDoacao(Doacao d)
        {
            _context.Doacoes.Update(d);
            _context.SaveChanges();
        }
    }
}
