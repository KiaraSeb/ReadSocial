namespace ReadSocial.Models
{
public class Post
{
    public int PostId { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime CreatedAt { get; set; }

    // Relación con DiscussionThread
    public int ThreadId { get; set; } // Clave foránea
    public DiscussionThread Thread { get; set; } // Propiedad de navegación
}



}