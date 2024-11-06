using Microsoft.EntityFrameworkCore;          // Importa EF Core para DbContext
using ReadSocial.Models;                      // Importa las clases de tu proyecto, como Thread y Post

namespace ReadSocial.Data                     // Define el espacio de nombres
{
    // Define la clase ApplicationDbContext que hereda de DbContext
    public class ApplicationDbContext : DbContext
    {
        // Constructor que pasa opciones al DbContext base
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSet que representa la tabla de 'Threads' en la base de datos
        public DbSet<ReadSocial.Models.Thread> Threads { get; set; }

        // DbSet que representa la tabla de 'Posts' en la base de datos
        public DbSet<Post> Posts { get; set; }
    }
}
