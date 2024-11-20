using System;

namespace ReadSocial.Models
{
    public class Post
    {
        public int Id { get; set; } // ID del post
        public int ThreadId { get; set; } // ID del hilo al que pertenece
        public string Content { get; set; } // Contenido del post
        public string Author { get; set; } // Autor del post
        public DateTime CreatedAt { get; set; } // Fecha de creación
    }
}