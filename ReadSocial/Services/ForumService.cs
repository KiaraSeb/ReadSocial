using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadSocial.Data;
using ReadSocial.Dto;
using ReadSocial.Interfaces;
using ReadSocial.Models;

namespace ReadSocial.Services
{
    public class ForumService : IForumService
    {
        private readonly BibliotecaContext _context;

        public ForumService(BibliotecaContext context)
        {
            _context = context;
        }

        // Obtener todos los hilos
        public async Task<IEnumerable<ReadSocial.Models.Thread>> GetThreadsAsync()
        {
            return await _context.Threads.ToListAsync();
        }

        // Crear un nuevo hilo
        public async Task<ReadSocial.Models.Thread> CreateThreadAsync(CreateThreadDto dto)
        {
            var thread = new ReadSocial.Models.Thread
            {
                Title = dto.Title,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };

            _context.Threads.Add(thread);
            await _context.SaveChangesAsync();
            return thread;
        }

        // Crear un nuevo post
        public async Task<Post> CreatePostAsync(CreatePostDto dto)
        {
            var post = new Post
            {
                ThreadId = dto.ThreadId,
                Content = dto.Content,
                Author = dto.Author,
                CreatedAt = DateTime.UtcNow
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        // Obtener los posts de un hilo específico
        public async Task<IEnumerable<Post>> GetPostsByThreadAsync(int threadId)
        {
            return await _context.Posts
                .Where(p => p.ThreadId == threadId)
                .ToListAsync();
        }
    }
}
