using Microsoft.EntityFrameworkCore;
using ReadSocial.Models;


public class BibliotecaContext : DbContext
{
    public DbSet<DiscussionThread> Threads { get; set; } // Cambiado a DiscussionThread
    public DbSet<Post> Posts { get; set; }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de la entidad DiscussionThread
        modelBuilder.Entity<DiscussionThread>(entity =>
        {
            entity.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(t => t.CreatedAt)
                .IsRequired();

            entity.HasMany(t => t.Posts) // Aquí se define la relación uno a muchos
                .WithOne(p => p.Thread) // Relación inversa
                .HasForeignKey(p => p.ThreadId) // Clave foránea en Post
                .IsRequired();
        });

        // Configuración de la entidad Post
        modelBuilder.Entity<Post>(entity =>
        {
            entity.Property(p => p.Content)
                .IsRequired();

            entity.Property(p => p.CreatedAt)
                .IsRequired();

            entity.HasOne(p => p.Thread) // Relación inversa
                .WithMany(t => t.Posts) // Relación uno a muchos
                .HasForeignKey(p => p.ThreadId) // Clave foránea en Post
                .IsRequired();
        });
    }
}