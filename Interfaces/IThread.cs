namespace ReadSocial.Interfaces
{
    public interface IThread
    {
        int Id { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        List<IPost> Posts { get; set; }
        DateTime CreatedAt { get; set; }
    }
}