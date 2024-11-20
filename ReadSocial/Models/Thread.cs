using System;

namespace ReadSocial.Models
{
    public class Thread
    {
        public int Id { get; set; } // ID del hilo
        public string Title { get; set; } // Título del hilo
        public string Description { get; set; } // Descripción del hilo
        public DateTime CreatedAt { get; set; } // Fecha de creación
    }
}