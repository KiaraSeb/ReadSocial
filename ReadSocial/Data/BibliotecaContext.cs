using Microsoft.EntityFrameworkCore;
using ReadSocial.Models;

namespace ReadSocial.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        public DbSet<ReadSocial.Models.Thread> Threads { get; set; } // Uso explícito del namespace
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:cnBiblioteca");
            }
        }
    }
}
