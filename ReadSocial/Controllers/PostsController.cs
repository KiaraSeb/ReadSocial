using Microsoft.AspNetCore.Mvc;
using ReadSocial.Dto;
using ReadSocial.Interfaces;
using ReadSocial.Models;

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

        [HttpPost]
        public IActionResult CreatePost([FromBody] CreatePostDto dto)
        {
            var post = _forumService.CreatePost(dto);
            if (post == null) return NotFound("Thread not found.");
            return Ok(post);
        }

        [HttpGet("{threadId}")]
        public IActionResult GetPosts(int threadId)
        {
            var posts = _forumService.GetPosts(threadId);
            if (!posts.Any()) return NotFound("No posts found for this thread.");
            return Ok(posts);
        }
    }
}
