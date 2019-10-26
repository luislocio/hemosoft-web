using HemoSoft.Models;
using HemosoftWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HemoSoft.DAL
{
    class TriadorDAO
    {
        private readonly Context _context;
        public TriadorDAO(Context context)
        {
            _context = context;
        }

        public bool CadastrarTriador(Triador t)
        {
            if (BuscarTriadorPorMatricula(t) == null)
            {
                _context.Triadores.Add(t);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Triador BuscarTriadorPorMatricula(Triador t)
        {
            return _context.Triadores.FirstOrDefault
                (x => x.Matricula.Equals(t.Matricula));
        }

        public Triador BuscarTriadorPorId(Triador t)
        {
            return _context.Triadores.FirstOrDefault
                (x => x.IdTriador.Equals(t.IdTriador));
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