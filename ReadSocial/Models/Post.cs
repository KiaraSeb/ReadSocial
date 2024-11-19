namespace ReadSocial.Models
{
public class Post
    {
        public int PostId { get; set; }
        public int ThreadId { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
