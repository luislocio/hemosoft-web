using HemoSoft.Models;
using HemosoftWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HemosoftWeb.DAL
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

        public Doador BuscarDoadorPorNomeCompleto(Doador d)
        {
            return _context.Doadores.FirstOrDefault
                (x => x.NomeCompleto.Equals(d.NomeCompleto));
        }

        public List<Doador> BuscarDoadorPorParteNome(Doador d)
        {
            //Where: é método que retorna todas as ocorrências em uma busca
            return _context.Doadores.Where
                (x => x.NomeCompleto.Contains(d.NomeCompleto)).ToList();
        }

        public Doador BuscarDoadorPorEstadoCivil(Doador d)
        {
            return _context.Doadores.FirstOrDefault
                (x => x.EstadoCivil.Equals(d.EstadoCivil));
        }

        public void AlterarDoador(Doador d)
        {
            _context.Doadores.Update(d);
            _context.SaveChanges();
        }
    }
}

