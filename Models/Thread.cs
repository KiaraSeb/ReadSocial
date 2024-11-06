using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReadSocial.Models
{
    public class Thread
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        // Relación uno a muchos con la clase Post
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
