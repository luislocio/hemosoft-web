using Microsoft.EntityFrameworkCore;

namespace HemosoftWeb.Models
{
    public class Context : DbContext
    { 
        public Context(DbContextOptions<Context> options) : base(options)
        {
            // TODO: Database.SetInitializer(new SeedUsuariosPadrao());
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
