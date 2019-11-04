using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DatingAppDbContext : DbContext
    {
        public DatingAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {  }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(x => x.Document);
        }
        public DbSet<Valor> Valores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Foto> Fotos { get; set; }
    }
}
