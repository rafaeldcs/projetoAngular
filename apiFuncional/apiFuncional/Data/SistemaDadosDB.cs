using apiTestes.Data.Map;
using apiTestes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;

namespace apiTestes.Data
{
    public class SistemaDadosDB : DbContext
    {
        public SistemaDadosDB(DbContextOptions<SistemaDadosDB> options)
            : base(options)
        {
        }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        protected  override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new ContatoMap());

            base.OnModelCreating(modelBuilder);  
        }

    }
}
