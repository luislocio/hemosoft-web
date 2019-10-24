using HemoSoft.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HemoSoft.DAL
{
    class DoadorDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static bool CadastrarDoador(Doador d)
        {
            if (BuscarDoadorPorCpf(d) != null)
            {
                return false;
            }

            ctx.Doadores.Add(d);
            ctx.SaveChanges();
            return true;
        }

        public static Doador BuscarDoadorPorCpf(Doador d)
        {
            return ctx.Doadores
                .Include("Doacoes")
                .FirstOrDefault(x => x.Cpf.Equals(d.Cpf));
        }

        public static Doador BuscarDoadorPorNomeCompleto(Doador d)
        {
            return ctx.Doadores.FirstOrDefault
                (x => x.NomeCompleto.Equals(d.NomeCompleto));
        }

        public static List<Doador> BuscarDoadorPorParteNome(Doador d)
        {
            //Where: é método que retorna todas as ocorrências em uma busca
            return ctx.Doadores.Where
                (x => x.NomeCompleto.Contains(d.NomeCompleto)).ToList();
        }

        public static Doador BuscarDoadorPorEstadoCivil(Doador d)
        {
            return ctx.Doadores.FirstOrDefault
                (x => x.EstadoCivil.Equals(d.EstadoCivil));
        }

        public static void AlterarDoador(Doador d)
        {
            ctx.Entry(d).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}

