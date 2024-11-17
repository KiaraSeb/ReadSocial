using System.Collections.Generic;
using System.Threading.Tasks;
using ReadSocial.Dto;
using ReadSocial.Models;
using Thread = ReadSocial.Models.Thread; // Alias explícito para Thread

namespace ReadSocial.Interfaces
{
    public interface IForumService
    {
        Task<Thread> CreateThreadAsync(CreateThreadDto dto); // Usando el alias explícito
        List<Thread> GetThreads();
        Post CreatePost(CreatePostDto dto);
        List<Post> GetPosts(int threadId);
    }
}
