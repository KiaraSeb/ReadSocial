using System.Collections.Generic;

namespace ReadSocial.Models
{
    public class Thread
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public List<Post> Posts { get; set; } // Asegúrate de que esta propiedad sea de tipo List<Post>

        public Thread()
        {
            Posts = new List<Post>(); // Inicializa la lista en el constructor
        }
    }
}
