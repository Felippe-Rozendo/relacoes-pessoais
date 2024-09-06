using Microsoft.EntityFrameworkCore;
using relacoes_pessoais_api.Dominio.Entidades;

namespace relacoes_pessoais_api.Infraestrutura.Context
{
    public class RelacoesPessoaisDB : DbContext
    {
        public RelacoesPessoaisDB(DbContextOptions<RelacoesPessoaisDB> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>().HasKey(k => k.CodPessoa);
            modelBuilder.Entity<Contato>().HasKey(k => k.CodContato);

            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Contatos)
                .WithOne(c => c.Pessoa)
                .HasForeignKey(c => c.CodPessoa);

            base.OnModelCreating(modelBuilder);
        }

    }
}
