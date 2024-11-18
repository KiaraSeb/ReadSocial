using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadSocial.Data;
using ReadSocial.Dto;
using ReadSocial.Interfaces;
using ReadSocial.Models;
using Thread = ReadSocial.Models.Thread;


namespace ReadSocial.Services
{
    public class ForumService : IForumService
    {
        private readonly BibliotecaContext _context;

        public ForumService(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<List<Thread>> GetThreads()
        {
            return await _context.Threads.ToListAsync();
        }

        public async Task<Thread> CreateThreadAsync(CreateThreadDto dto)
        {
            var thread = new Thread
            {
                Title = dto.Title,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };

            _context.Threads.Add(thread);
            await _context.SaveChangesAsync();

            return thread;
        }

        Task<List<System.Threading.Thread>> IForumService.GetThreads()
        {
            throw new NotImplementedException();
        }

        Task<System.Threading.Thread> IForumService.CreateThreadAsync(CreateThreadDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetPostsByThreadAsync(int threadId)
        {
            throw new NotImplementedException();
        }

        public Task<Post> CreatePostAsync(CreatePostDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
