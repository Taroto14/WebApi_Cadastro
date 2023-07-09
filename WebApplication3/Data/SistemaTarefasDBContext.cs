using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Data.Map;
using PrimeiraApi.Models;

namespace PrimeiraApi.Data
{
    public class SistemaTarefasDBContext : DbContext
    {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options) : base(options)
        {

        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-2CVODJ7;Database=APPTest;Trusted_Connection=True;Password=123456sa;User ID=sa;Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
