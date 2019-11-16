using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repository.DAL
{
    public class DoacaoDAO
    {
        private readonly Context _context;

        public DoacaoDAO(Context context)
        {
            _context = context;
        }

        public int CadastrarDoacao(Doacao d)
        {
            _context.Doacoes.Add(d);
            _context.SaveChanges();
            return d.IdDoacao;
        }

        public bool VerificarDoacoesPorStatusTriagemLaboratorial(TriagemLaboratorial t)
        {
            return _context.Doacoes.Any(x => x.TriagemLaboratorial.StatusTriagem == t.StatusTriagem);
        }

        public Doacao BuscarDoacaoPorId(int? idDoacao)
        {
            //Where: é método que retorna todas as
            //ocorrências em uma busca
            return _context.Doacoes
                .Include("Doador")
                .Include("TriagemClinica")
                .Include("TriagemLaboratorial")
                .Include("ImpedimentosTemporarios")
                .Include("ImpedimentosDefinitivos")
                .FirstOrDefault(x => x.IdDoacao.Equals(idDoacao));
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