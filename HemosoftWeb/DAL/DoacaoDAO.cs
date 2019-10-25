using HemoSoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HemoSoft.DAL
{
    class DoacaoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarDoacao(Doacao d)
        {
            ctx.Doacoes.Add(d);
            ctx.SaveChanges();
        }

        public static Doacao BuscarUltimaDoacaoPorDoador(Doador d)
        {
            //Where: é método que retorna todas as
            //ocorrências em uma busca
            return ctx.Doacoes
                .Include("Doador")
                .Include("TriagemClinica")
                .Include("TriagemLaboratorial")
                .Include("ImpedimentosTemporarios")
                .Include("ImpedimentosDefinitivos")
                .OrderByDescending(x => x.DataDoacao)
                .FirstOrDefault(x => x.Doador.IdDoador.Equals(d.IdDoador));
        }

        public static bool VerificarDoacoesPorStatusTriagemLaboratorial(TriagemLaboratorial t)
        {
            return ctx.Doacoes.Any(x => x.TriagemLaboratorial.StatusTriagem == t.StatusTriagem);
        }

        public static Doacao BuscarDoacaoPorId(Doacao d)
        {
            //Where: é método que retorna todas as
            //ocorrências em uma busca
            return ctx.Doacoes
                .Include("Doador")
                .Include("TriagemClinica")
                .Include("TriagemLaboratorial")
                .Include("ImpedimentosTemporarios")
                .Include("ImpedimentosDefinitivos")
                .FirstOrDefault(x => x.IdDoacao.Equals(d.IdDoacao));
        }

        public static List<Doacao> BuscarDoacaoPorStatus(Doacao d)
        {
            //Where: é método que retorna todas as
            //ocorrências em uma busca
            return ctx.Doacoes
                .Include("Doador")
                .Include("TriagemClinica")
                .Include("TriagemLaboratorial")
                .Include("ImpedimentosTemporarios")
                .Include("ImpedimentosDefinitivos")
                .Where(x => x.StatusDoacao == d.StatusDoacao).ToList();
        }

        public static void AlterarDoacao(Doacao d)
        {
            ctx.Entry(d).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
