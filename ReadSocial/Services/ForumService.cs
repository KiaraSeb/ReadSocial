using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Obtener todos los hilos
        public async Task<IEnumerable<ThreadDto>> GetAllThreadsAsync()
        {
            return await _context.Threads
                .AsNoTracking() // Mejora el rendimiento para consultas de solo lectura
                .Select(thread => new ThreadDto
                {
                    Id = thread.ThreadId,
                    Title = thread.Title,
                    Description = thread.Description,
                    CreatedAt = thread.CreatedAt
                })
                .ToListAsync();
        }

        // Obtener un hilo por ID
        public async Task<ThreadDto> GetThreadByIdAsync(int id)
        {
            var thread = await _context.Threads
                .AsNoTracking() // Mejora el rendimiento
                .FirstOrDefaultAsync(t => t.ThreadId == id);

            if (thread == null)
            {
                return null; // Puede reemplazarse con una excepción si es necesario
            }

            return new ThreadDto
            {
                Id = thread.ThreadId,
                Title = thread.Title,
                Description = thread.Description,
                CreatedAt = thread.CreatedAt
            };
        }

        // Crear un nuevo hilo
        public async Task<ThreadDto> CreateThreadAsync(CreateThreadDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var thread = new DiscussionThread
            {
                Title = dto.Title,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };

            _context.Threads.Add(thread);
            await _context.SaveChangesAsync();

            return new ThreadDto
            {
                Id = thread.ThreadId,
                Title = thread.Title,
                Description = thread.Description,
                CreatedAt = thread.CreatedAt
            };
        }

        // Obtener todos los posts
        public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
        {
            return await _context.Posts
                .AsNoTracking()
                .Select(post => new PostDto
                {
                    Id = post.PostId, // Cambiado a PostId
                    ThreadId = post.ThreadId,
                    Content = post.Content,
                    Author = post.Author,
                    CreatedAt = post.CreatedAt
                })
                .ToListAsync();
        }

        // Obtener un post por ID
        public async Task<PostDto> GetPostByIdAsync(int postId)
        {
            var post = await _context.Posts
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PostId == postId);

            if (post == null)
            {
                return null;
            }

            return new PostDto
            {
                Id = post.PostId, // Cambiado a PostId
                ThreadId = post.ThreadId,
                Content = post.Content,
                Author = post.Author,
                CreatedAt = post.CreatedAt
            };
        }

        // Crear un nuevo post
        public async Task<PostDto> CreatePostAsync(CreatePostDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var post = new Post
            {
                ThreadId = dto.ThreadId,
                Content = dto.Content,
                Author = dto.Author,
                CreatedAt = DateTime.UtcNow
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return new PostDto
            {
                Id = post.PostId, // Cambiado a PostId
                ThreadId = post.ThreadId,
                Content = post.Content,
                Author = post.Author,
                CreatedAt = post.CreatedAt
            };
        }

        // Actualizar un post
        public async Task<PostDto> UpdatePostAsync(UpdatePostDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var post = await _context.Posts.FindAsync(dto.Id);
            if (post == null)
            {
                return null;
            }

            post.Content = dto.Content;
            post.Author = dto.Author;

            _context.Posts.Update(post);
            await _context.SaveChangesAsync();

            return new PostDto
            {
                Id = post.PostId, // Cambiado a PostId
                ThreadId = post.ThreadId,
                Content = post.Content,
                Author = post.Author,
                CreatedAt = post.CreatedAt
            };
        }

        // Eliminar un post por ID
        public async Task<bool> DeletePostAsync(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);

            if (post == null)
            {
                return false; // Retorna false si no se encuentra el post
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return true; // Retorna true si se eliminó correctamente
        }
    }
}
