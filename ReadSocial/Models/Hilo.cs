public class Hilo
{
    public int Id { get; set; } // Identificador único del hilo
    public string Titulo { get; set; } // Título del hilo
    public string? Descripcion { get; set; } // Descripción opcional del hilo

    public DateTime FechaCreacion { get; set; } // Fecha de creación del hilo
    public int? UsuarioId { get; set; } // ID del usuario que creó el hilo

    public List<Post> Posts { get; set; } // Lista de posts asociados al hilo

    public Hilo()
    {
        Posts = new List<Post>();
    }
}
