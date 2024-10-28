using ReadSocial.Interfaces;

namespace ReadSocial.Models
{
    public class Post : IPost
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}