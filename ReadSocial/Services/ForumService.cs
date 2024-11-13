using System.Threading; // Agregar para poder usar Thread de System.Threading
using ReadSocial.Models; // Para los modelos personalizados, como Thread
using ReadSocial.Dto;
using ReadSocial.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadSocial.Services
{
    public class ForumService : IForumService
    {
        private List<ReadSocial.Models.Thread> _threads = new List<ReadSocial.Models.Thread>();

        public async Task<ReadSocial.Models.Thread> CreateThreadAsync(CreateThreadDto dto)
        {
            var newThread = new ReadSocial.Models.Thread
            {
                Id = _threads.Count + 1,
                Title = dto.Title,
                Posts = new List<Post>()
            };
            _threads.Add(newThread);
            return await Task.FromResult(newThread);
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
            if (thread == null)
            {
                return new List<Post>();
            }
            return thread.Posts;
        }
    }
}
