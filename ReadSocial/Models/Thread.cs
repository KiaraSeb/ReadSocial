namespace ReadSocial.Models
{
    public class Thread
    {
        public int Id { get; set; }
        public string Title { get; set; }
         public string Description { get; set; }
        public List<Post> Posts { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
