using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository.DAL
{
    public class SolicitanteDAO
    {
        private readonly Context _context;
        public SolicitanteDAO(Context context)
        {
            _context = context;
        }

        public bool CadastrarSolicitante(Solicitante s)
        {
            if (BuscarSolicitantePorCnpj(s) == null)
            {
                s.StatusUsuario = Domain.Enum.StatusUsuario.Ativo;

                _context.Solicitantes.Add(s);
                _context.SaveChanges();

                return true;
            }

                       return false;
        }

        public Solicitante BuscarSolicitantePorCnpj(Solicitante s)
        {
            return _context.Solicitantes.FirstOrDefault
                (x => x.Cnpj.Equals(s.Cnpj));
        }

        public Solicitante BuscarSolicitantePorId(Solicitante s)
        {
            return _context.Solicitantes.FirstOrDefault
                (x => x.IdSolicitante.Equals(s.IdSolicitante));
        }

        public Solicitante BuscarSolicitantePorRazaoSocial(Solicitante s)
        {
            return _context.Solicitantes.FirstOrDefault
                (x => x.RazaoSocial.Equals(s.RazaoSocial));
        }


        public List<Solicitante> BuscarSolicitantesPorParteDoNome(Solicitante s)
        {
            //Where: é método que retorna todas as ocorrências em uma busca
            return _context.Solicitantes.Where
                (x => x.RazaoSocial.Contains(s.RazaoSocial)).ToList();
        }

        public List<Solicitante> ListarSolicitantes()
        {
            return _context.Solicitantes.ToList();
        }

        public void AlterarSolicitante(Solicitante s)
        {
            _context.Solicitantes.Update(s);
            _context.SaveChanges();
        }
    }
}

