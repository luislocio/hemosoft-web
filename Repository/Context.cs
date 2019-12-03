using Domain.Enum;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Triador>().HasData(
                new Triador()
                {
                    IdTriador = 1,
                    Matricula = "1111111",
                    NomeCompleto = "Triador 1",
                    Senha = "senhatriador",
                    StatusUsuario = StatusUsuario.Ativo
                },
                new Triador()
                {
                    IdTriador = 2,
                    Matricula = "1234567",
                    NomeCompleto = "Triador 2",
                    Senha = "senhatriador",
                    StatusUsuario = StatusUsuario.Ativo
                },
                new Triador()
                {
                    IdTriador = 3,
                    Matricula = "3333333",
                    NomeCompleto = "Triador 3",
                    Senha = "senhatriador",
                    StatusUsuario = StatusUsuario.Inativo
                });

            modelBuilder.Entity<Solicitante>().HasData(
                new Solicitante
                {
                    IdSolicitante = 1,
                    Cnpj = "11111111111111",
                    RazaoSocial = "Solicitante 1",
                    Responsavel = "Responsavel 1",
                    Senha = "senhasolicitante",
                    StatusUsuario = StatusUsuario.Ativo
                },
                new Solicitante
                {
                    IdSolicitante = 2,
                    Cnpj = "12345678901234",
                    RazaoSocial = "Solicitante 2",
                    Responsavel = "Responsavel 2",
                    Senha = "senhasolicitante",
                    StatusUsuario = StatusUsuario.Ativo
                },
                new Solicitante
                {
                    IdSolicitante = 3,
                    Cnpj = "33333333333333",
                    RazaoSocial = "Solicitante 3",
                    Responsavel = "Responsavel 3",
                    Senha = "senhasolicitante",
                    StatusUsuario = StatusUsuario.Inativo
                });

            base.OnModelCreating(modelBuilder);
        }

        //Definir as classes que são tabelas no banco
        public DbSet<Doacao> Doacoes { get; set; }

        public DbSet<Doador> Doadores { get; set; }
        public DbSet<ImpedimentosDefinitivos> ImpedimentosDefinitivos { get; set; }
        public DbSet<ImpedimentosTemporarios> ImpedimentosTemporarios { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }
        public DbSet<Solicitante> Solicitantes { get; set; }
        public DbSet<Triador> Triadores { get; set; }
        public DbSet<TriagemClinica> TriagensClinicas { get; set; }
        public DbSet<TriagemLaboratorial> TriagensLaboratoriais { get; set; }
    }
}