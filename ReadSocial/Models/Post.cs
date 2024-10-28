namespace ReadSocial.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int ThreadId { get; set; } // Referencia al hilo al que pertenece
        public string Author { get; set; }
        public string Content { get; set; }
    }
}
