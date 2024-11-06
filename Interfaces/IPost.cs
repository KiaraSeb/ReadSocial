namespace ReadSocial.Interfaces
{
    public interface IPost
    {
        int Id { get; set; }
        int ThreadId { get; set; }
        string Author { get; set; }
        string Content { get; set; }
        DateTime CreatedAt { get; set; }
    }
}