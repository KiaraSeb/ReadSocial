using ReadSocial.Interfaces;  // Agrega esta línea para importar la interfaz
using ReadSocial.Services;    // Asegúrate de importar también los servicios
using ReadSocial.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ReadSocial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly IForumService _forumService; // Usa la interfaz IForumService

        public ForumController(IForumService forumService) // Inyección de dependencia
        {
            _forumService = forumService;
        }

        [HttpPost("threads")]
        public async Task<IActionResult> CreateThread([FromBody] CreateThreadDto dto)
        {
            var thread = await _forumService.CreateThreadAsync(dto);
            return Ok(thread);
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
