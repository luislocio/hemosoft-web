using HemoSoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HemoSoft.DAL
{
    class DoadorDAO
    {
        private readonly Context _context;
        public DoadorDAO(Context context)
        {
            _context = context;
        }

        public static bool CadastrarDoador(Doador d)
        {
            if (BuscarDoadorPorCpf(d) != null)
            {
                return false;
            }

            _context.Doadores.Add(d);
            _context.SaveChanges();
            return true;
        }

        public static Doador BuscarDoadorPorCpf(Doador d)
        {
            return _context.Doadores
                .Include("Doacoes")
                .FirstOrDefault(x => x.Cpf.Equals(d.Cpf));
        }

        public static Doador BuscarDoadorPorNomeCompleto(Doador d)
        {
            return _context.Doadores.FirstOrDefault
                (x => x.NomeCompleto.Equals(d.NomeCompleto));
        }

        public static List<Doador> BuscarDoadorPorParteNome(Doador d)
        {
            //Where: é método que retorna todas as ocorrências em uma busca
            return _context.Doadores.Where
                (x => x.NomeCompleto.Contains(d.NomeCompleto)).ToList();
        }

        public static Doador BuscarDoadorPorEstadoCivil(Doador d)
        {
            return _context.Doadores.FirstOrDefault
                (x => x.EstadoCivil.Equals(d.EstadoCivil));
        }

        public static void AlterarDoador(Doador d)
        {
            _context.Entry(d).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

