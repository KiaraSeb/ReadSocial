using ReadSocial.Models;
using ReadSocial.Dto;

namespace ReadSocial.Services
{
    public class ForumService
    {
        private List<Thread> _threads = new List<Thread>();

        public Thread CreateThread(CreateThreadDto dto)
        {
            var newThread = new Thread
            {
                Id = _threads.Count + 1,
                Title = dto.Title,
                Author = dto.Author
            };
            _threads.Add(newThread);
            return newThread;
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
