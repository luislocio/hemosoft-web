using HemoSoft.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoSoft.DAL
{
    class SolicitanteDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarSolicitante(Solicitante s)
        {
            if (BuscarSolicitantePorCnpj(s) != null)
            {
                return false;
            }

            ctx.Solicitantes.Add(s);
            ctx.SaveChanges();
            return true;
        }

        public static Solicitante BuscarSolicitantePorCnpj(Solicitante s)
        {
            return ctx.Solicitantes.FirstOrDefault
                (x => x.Cnpj.Equals(s.Cnpj));
        }

        public static Solicitante BuscarSolicitantePorId(Solicitante s)
        {
            return ctx.Solicitantes.FirstOrDefault
                (x => x.IdSolicitante.Equals(s.IdSolicitante));
        }

        public static Solicitante BuscarSolicitantePorRazaoSocial(Solicitante s)
        {
            return ctx.Solicitantes.FirstOrDefault
                (x => x.RazaoSocial.Equals(s.RazaoSocial));
        }


        public static List<Solicitante> BuscarSolicitantesPorParteDoNome(Solicitante s)
        {
            //Where: é método que retorna todas as ocorrências em uma busca
            return ctx.Solicitantes.Where
                (x => x.RazaoSocial.Contains(s.RazaoSocial)).ToList();
        }

        public static List<Solicitante> ListarSolicitantes()
        {
            return ctx.Solicitantes.ToList();
        }

        public static void AlterarSolicitante(Solicitante s)
        {
            ctx.Entry(s).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}

