using System;
using System.Collections.Generic;

namespace ReadSocial.Models
{
   public class DiscussionThread
{
    public int ThreadId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    // Colección de Posts relacionados
    public ICollection<Post> Posts { get; set; }
}

}