using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReadSocial.Dto;
using ReadSocial.Interfaces;
using ReadSocial.Models;
using Thread = ReadSocial.Models.Thread; // Alias explícito para Thread

namespace ReadSocial.Services
{
    public class ForumService : IForumService
    {
        private readonly List<Thread> _threads = new();

        public async Task<Thread> CreateThreadAsync(CreateThreadDto dto)
        {
            var newThread = new Thread
            {
                Id = _threads.Count + 1,
                Title = dto.Title,
                Posts = new List<Post>()
            };
            _threads.Add(newThread);
            return await Task.FromResult(newThread);
        }

        public List<Thread> GetThreads()
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
            return thread?.Posts ?? new List<Post>();
        }
    }
}
