using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repository.DAL
{
    public class DoadorDAO
    {
        private readonly Context _context;
        public DoadorDAO(Context context)
        {
            _context = context;
        }

        //Métodos dentro de um controller são de chamados de actions
        public bool CadastrarDoador(Doador d)
        {
            if (BuscarDoadorPorCpf(d) == null)
            {
                _context.Doadores.Add(d);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Doador BuscarDoadorPorCpf(Doador d)
        {
            return _context.Doadores
                .Include("Doacoes")
                .FirstOrDefault(x => x.Cpf.Equals(d.Cpf));
        }

        public Doador BuscarDoadorPorId(Doador d)
        {
            return _context.Doadores
                .Include("Doacoes")
                .FirstOrDefault(x => x.IdDoador.Equals(d.IdDoador));
        }

        public void AlterarDoador(Doador doador)
        {
            _context.Doadores.Update(doador);
            _context.SaveChanges();
        }
    }
}

