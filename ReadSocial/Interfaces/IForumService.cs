using System.Collections.Generic;
using System.Threading.Tasks;
using ReadSocial.Dto;
using ReadSocial.Models;

namespace ReadSocial.Interfaces
{
    public interface IForumService
    {
        // Obtener todos los hilos
        Task<IEnumerable<ReadSocial.Models.Thread>> GetThreadsAsync();

        // Crear un nuevo hilo
        Task<ReadSocial.Models.Thread> CreateThreadAsync(CreateThreadDto dto);

        // Crear un nuevo post
        Task<Post> CreatePostAsync(CreatePostDto dto);

        // Obtener los posts de un hilo específico
        Task<IEnumerable<Post>> GetPostsByThreadAsync(int threadId);
    }
}
