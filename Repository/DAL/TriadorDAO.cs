using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository.DAL
{
    public class TriadorDAO
    {
        private readonly Context _context;
        public TriadorDAO(Context context)
        {
            _context = context;
        }

        public int CadastrarTriador(Triador t)
        {
            Triador buscaNoDatabase = BuscarTriadorPorMatricula(t);

            if (buscaNoDatabase == null)
            {
                t.StatusUsuario = Domain.Enum.StatusUsuario.Ativo;

                _context.Triadores.Add(t);
                _context.SaveChanges();

                // Id do triador cadastro no database.
                return t.IdTriador;
            }

            // Id do triador encontrado no database.
            return buscaNoDatabase.IdTriador;
        }

        public Triador BuscarTriadorPorMatricula(Triador t)
        {
            return _context.Triadores.FirstOrDefault
                (x => x.Matricula.Equals(t.Matricula));
        }

        public Triador BuscarTriadorPorId(int? id)
        {
            return _context.Triadores.FirstOrDefault
                (x => x.IdTriador.Equals(id));
        }

        public List<Triador> ListarTriadores()
        {
            return _context.Triadores.ToList();
        }

        public void AlterarTriador(Triador t)
        {
            _context.Triadores.Update(t);
            _context.SaveChanges();
        }
    }
}