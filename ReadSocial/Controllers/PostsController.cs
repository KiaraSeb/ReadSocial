using Microsoft.AspNetCore.Mvc;
using ReadSocial.Interfaces;
using ReadSocial.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadSocial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IForumService _forumService;

        public PostsController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPosts()
        {
            var posts = await _forumService.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{postId}")]
        public async Task<ActionResult<PostDto>> GetPostById(int postId)
        {
            var post = await _forumService.GetPostByIdAsync(postId);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        // Otros métodos para crear, actualizar y eliminar posts...
    }
}