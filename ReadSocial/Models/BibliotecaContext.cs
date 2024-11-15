using Microsoft.EntityFrameworkCore;
using ReadSocial.Models;  // Usar el Thread de tu propio modelo

namespace ReadSocial.Data // Ajusta el namespace si es necesario
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        // Define las entidades que estarán en tu base de datos
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        // Agrega aquí otros DbSet si tienes más entidades

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:cnBiblioteca");
            }
        }
    }
}
