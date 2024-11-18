using ReadSocial.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thread = System.Threading.Thread;
using ReadSocial.Dto;

namespace ReadSocial.Interfaces
{
    public interface IForumService
{
    Task<List<Thread>> GetThreads();
    Task<Thread> CreateThreadAsync(CreateThreadDto dto);  // Aquí debe devolver Task<Thread>
    Task<List<Post>> GetPostsByThreadAsync(int threadId);
    Task<Post> CreatePostAsync(CreatePostDto dto);

}

}
