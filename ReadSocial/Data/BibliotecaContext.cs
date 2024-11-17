using Microsoft.EntityFrameworkCore;
using ReadSocial.Models;
using Thread = ReadSocial.Models.Thread; // Alias explícito para Thread

namespace ReadSocial.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        public DbSet<Thread> Threads { get; set; } // Alias explícito para evitar ambigüedad
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
