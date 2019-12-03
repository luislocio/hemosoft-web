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

        public int CadastrarDoador(Doador d)
        {
            Doador buscaNoDatabase = BuscarDoadorPorCpf(d);

            if (BuscarDoadorPorCpf(d) == null)
            {
                _context.Doadores.Add(d);
                _context.SaveChanges();

                // Id do doador cadastro no database.
                return d.IdDoador;
            }

            // Id do doador encontrado no database.
            return buscaNoDatabase.IdDoador;
        }

        public Doador BuscarDoadorPorCpf(Doador d)
        {
            return _context.Doadores
                .Include("Doacoes")
                .FirstOrDefault(x => x.Cpf.Equals(d.Cpf));
        }

        public List<Doador> BuscarDoadorPorTipoSanguineo(Doador d)
        {
            return _context.Doadores
                .Include("Doacoes")
                .Where(x => x.TipoSanguineo.Equals(d.TipoSanguineo))
                .Where(x => x.FatorRh.Equals(d.FatorRh)).ToList();
        }

        public Doador BuscarDoadorPorId(int? id)
        {
            return _context.Doadores
                .Include("Doacoes")
                .FirstOrDefault(x => x.IdDoador.Equals(id));
        }

        public void AlterarDoador(Doador doador)
        {
            _context.Doadores.Update(doador);
            _context.SaveChanges();
        }
    }
}