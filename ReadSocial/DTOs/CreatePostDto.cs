namespace ReadSocial.Dto
{
    public class CreatePostDto
    {
        public int ThreadId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}