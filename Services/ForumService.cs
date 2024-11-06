using ReadSocial.Dto; // Importa los DTOs
using ReadSocial.Models; // Importa los modelos
using System.Collections.Generic;
using System.Linq;

namespace ReadSocial.Services
{
    public class ForumService
    {
        private List<ReadSocial.Models.Thread> _threads = new List<ReadSocial.Models.Thread>();

        public ReadSocial.Models.Thread CreateThread(CreateThreadDto dto)
        {
            var newThread = new ReadSocial.Models.Thread
            {
                Id = _threads.Count + 1,
                Title = dto.Title,
                Author = dto.Author,
                Posts = new List<Post>() // Inicializa la lista de posts
            };
            _threads.Add(newThread);
            return newThread;
        }

        public List<ReadSocial.Models.Thread> GetThreads()
        {
            return _threads;
        }

        public Post CreatePost(CreatePostDto dto)
        {
            var thread = _threads.FirstOrDefault(t => t.Id == dto.ThreadId);
            if (thread == null) return null;

            var newPost = new Post
            {
                Id = thread.Posts.Count + 1,
                ThreadId = dto.ThreadId,
                Author = dto.Author,
                Content = dto.Content
            };
            thread.Posts.Add(newPost);
            return newPost;
        }

        public List<Post> GetPosts(int threadId)
        {
            var thread = _threads.FirstOrDefault(t => t.Id == threadId);
            
            // Verificamos si thread es null antes de acceder a Posts
            if (thread == null)
            {
                return new List<Post>(); // Retorna una lista vacía si el thread no existe
            }

            return thread.Posts; // Si thread no es null, retornamos su lista de Posts
        }
    }
}
