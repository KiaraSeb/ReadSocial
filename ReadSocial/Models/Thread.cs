using ReadSocial.Interfaces;

namespace ReadSocial.Models
{
    public class Thread : IThread
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public List<IPost> Posts { get; set; } = new List<IPost>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
