using ReadSocial.Dto;
using ReadSocial.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadSocial.Interfaces
{
    public interface IForumService
    {
        // Usamos un alias para evitar la ambigüedad de nombres
        Task<ReadSocial.Models.Thread> CreateThreadAsync(CreateThreadDto dto);
        List<ReadSocial.Models.Thread> GetThreads();
        Post CreatePost(CreatePostDto dto);
        List<Post> GetPosts(int threadId);
    }
}

