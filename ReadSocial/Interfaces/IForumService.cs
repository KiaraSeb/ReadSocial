using ReadSocial.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadSocial.Interfaces
{
    public interface IForumService
    {
        Task<IEnumerable<ThreadDto>> GetAllThreadsAsync();
        Task<ThreadDto> GetThreadByIdAsync(int id);
        Task<ThreadDto> CreateThreadAsync(CreateThreadDto dto);
        
        // Métodos para los posts
        Task<IEnumerable<PostDto>> GetAllPostsAsync(); // Método para obtener todos los posts
        Task<PostDto> GetPostByIdAsync(int postId); // Método para obtener un post por ID
        Task<PostDto> CreatePostAsync(CreatePostDto dto); // Método para crear un nuevo post
        Task<PostDto> UpdatePostAsync(UpdatePostDto dto);  // Método para actualizar un post
        Task<bool> DeletePostAsync(int postId); // Método para eliminar un post
    }
}