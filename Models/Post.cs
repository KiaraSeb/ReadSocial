using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadSocial.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        // Foreign Key que apunta al Thread
        [ForeignKey("Thread")]
        public int ThreadId { get; set; }
        public Thread Thread { get; set; }
    }
}
