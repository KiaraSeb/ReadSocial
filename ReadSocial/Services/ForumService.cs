using System;
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
        public async Task<IEnumerable<ThreadDto>> GetAllThreadsAsync()
        {
            return await _context.Threads
                .Select(thread => new ThreadDto
                {
                    Id = thread.Id,
                    Title = thread.Title,
                    Description = thread.Description,
                    CreatedAt = thread.CreatedAt
                })
                .ToListAsync();
        }

        // Obtener un hilo por ID
        public async Task<ThreadDto> GetThreadByIdAsync(int id)
        {
            var thread = await _context.Threads.FindAsync(id);
            if (thread == null)
            {
                return null; // O lanzar una excepción según tu lógica
            }

            return new ThreadDto
            {
                Id = thread.Id,
                Title = thread.Title,
                Description = thread.Description,
                CreatedAt = thread.CreatedAt
            };
        }

        // Crear un nuevo hilo
        public async Task<ThreadDto> CreateThreadAsync(CreateThreadDto dto)
        {
            var thread = new ReadSocial.Models.Thread // Usando el nombre completo
            {
                Title = dto.Title,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };

            _context.Threads.Add(thread);
            await _context.SaveChangesAsync();

            return new ThreadDto
            {
                Id = thread.Id,
                Title = thread.Title,
                Description = thread.Description,
                CreatedAt = thread.CreatedAt
            };
        }

        // Obtener todos los posts
        public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
        {
            return await _context.Posts
                .Select(post => new PostDto
                {
                    Id = post.Id,
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
            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                return null; // O lanzar una excepción según tu lógica
            }

            return new PostDto
            {
                Id = post.Id,
                ThreadId = post.ThreadId,
                Content = post.Content,
                Author = post.Author,
                CreatedAt = post.CreatedAt
            };
        }

        // Crear un nuevo post
        public async Task<PostDto> CreatePostAsync(CreatePostDto dto)
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

            return new PostDto
            {
                Id = post.Id,
                ThreadId = post.ThreadId,
                Content = post.Content,
                Author = post.Author,
                CreatedAt = post.CreatedAt
            };
        }

        // Actualizar un post
    // Actualizar un post
    public async Task<PostDto> UpdatePostAsync(UpdatePostDto dto)
    {
        var post = await _context.Posts.FindAsync(dto.Id); // Usar dto.Id para buscar el post
        if (post == null)
        {
            return null; // O lanzar una excepción según tu lógica
        }

        // Actualiza las propiedades del post
        post.Content = dto.Content;
        post.Author = dto.Author; // Si deseas permitir la actualización del autor
        await _context.SaveChangesAsync();

        return new PostDto
        {
            Id = post.Id,
            ThreadId = post.ThreadId,
            Content = post.Content,
            Author = post.Author,
            CreatedAt = post.CreatedAt
        };
}

        // Eliminar un post
        public async Task<bool> DeletePostAsync(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                return false; // O lanzar una excepción según tu lógica
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }

        // Obtener los posts de un hilo específico
        public async Task<IEnumerable<PostDto>> GetPostsByThreadAsync(int threadId)
        {
            return await _context.Posts
                .Where(p => p.ThreadId == threadId)
                .Select(post => new PostDto
                {
                    Id = post.Id,
                    ThreadId = post.ThreadId,
                    Content = post.Content,
                    Author = post.Author,
                    CreatedAt = post.CreatedAt
                })
                .ToListAsync();
        }
    }
}