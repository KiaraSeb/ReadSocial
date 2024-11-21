public class Post
{
    public int Id { get; set; } // Identificador único del post
    public string Contenido { get; set; } // Contenido del post
    public DateTime FechaCreacion { get; set; } // Fecha de creación del post

    public int HiloId { get; set; } // ID del hilo al que pertenece el post
    public Hilo Hilo { get; set; } // Relación de navegación al Hilo

    // Propiedad para vincular el post con un usuario (si existe la relación)
    public int? UsuarioId { get; set; } // ID del usuario que creó el post
    public Usuario Usuario { get; set; } // Relación de navegación con Usuario
}
