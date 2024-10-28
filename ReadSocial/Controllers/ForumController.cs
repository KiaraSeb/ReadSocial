using Microsoft.AspNetCore.Mvc;
using ReadSocial.Services;
using ReadSocial.Dto;

namespace ReadSocial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly ForumService _forumService = new ForumService();

        [HttpPost("threads")]
        public IActionResult CreateThread([FromBody] CreateThreadDto dto)
        {
            var thread = _forumService.CreateThread(dto);
            return CreatedAtAction(nameof(GetThreadById), new { id = thread.Id }, thread);
        }

        [HttpGet("threads")]
        public IActionResult GetThreads()
        {
            var threads = _forumService.GetThreads();
            return Ok(threads);
        }

        [HttpPost("posts")]
        public IActionResult CreatePost([FromBody] CreatePostDto dto)
        {
            var post = _forumService.CreatePost(dto);
            if (post == null) return NotFound("Thread not found.");
            return Ok(post);
        }

        [HttpGet("threads/{threadId}/posts")]
        public IActionResult GetPosts(int threadId)
        {
            var posts = _forumService.GetPosts(threadId);
            if (!posts.Any()) return NotFound("No posts found for this thread.");
            return Ok(posts);
        }

        [HttpGet("threads/{id}")]
        public IActionResult GetThreadById(int id)
        {
            var thread = _forumService.GetThreads().FirstOrDefault(t => t.Id == id);
            if (thread == null) return NotFound("Thread not found.");
            return Ok(thread);
        }
    }
}
