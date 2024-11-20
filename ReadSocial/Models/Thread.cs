using System;

namespace ReadSocial.Models
{
    public class Thread
    {
    public int ThreadId { get; set; } // Clave primaria
    public string Title { get; set; } // Título del hilo
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } // Fecha de creación
    public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}