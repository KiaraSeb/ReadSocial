using Microsoft.EntityFrameworkCore;

public class ForoDbContext : DbContext
{
    public DbSet<Hilo> Hilos { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Usuario> Usuarios { get; set; } // Añadir la tabla de Usuarios

    public ForoDbContext(DbContextOptions<ForoDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de Hilos
        modelBuilder.Entity<Hilo>(entity =>
        {
            entity.Property(h => h.Titulo)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(h => h.Descripcion)
                .HasMaxLength(500);

            entity.Property(h => h.FechaCreacion)
                .IsRequired();

            // Relación Hilo - Post (Uno a Muchos)
            entity.HasMany(h => h.Posts)
                .WithOne(p => p.Hilo)
                .HasForeignKey(p => p.HiloId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configuración de Posts
        modelBuilder.Entity<Post>(entity =>
        {
            entity.Property(p => p.Contenido)
                .IsRequired()
                .HasMaxLength(1000);

            entity.Property(p => p.FechaCreacion)
                .IsRequired();

            // Relación Post - Usuario (Muchos a Uno)
            entity.HasOne(p => p.Usuario)
                .WithMany(u => u.Posts) // Un usuario puede tener muchos posts
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull); // Si el usuario es eliminado, no eliminar los posts
        });

        // Configuración de Usuario (si es necesario)
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(u => u.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);
        });
    }
}

