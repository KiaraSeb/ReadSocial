using Microsoft.AspNetCore.Mvc;
using ReadSocial.Interfaces;
using ReadSocial.Dto;
using ReadSocial.Models;

namespace ReadSocial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThreadsController : ControllerBase
    {
        private readonly IForumService _forumService;

        public ThreadsController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpGet]
        public IActionResult GetThreads()
        {
            var threads = _forumService.GetThreads();
            return Ok(threads);
        }

        [HttpPost]
        public async Task<IActionResult> CreateThread(CreateThreadDto dto)
        {
            var thread = await _forumService.CreateThreadAsync(dto);
            return CreatedAtAction(nameof(GetThreads), new { id = thread.Id }, thread);
        }

        [HttpGet("{id}/posts")]
        public IActionResult GetPosts(int id)
        {
            var posts = _forumService.GetPosts(id);
            return Ok(posts);
        }

        [HttpPost("{id}/posts")]
        public IActionResult CreatePost(int id, CreatePostDto dto)
        {
            dto.ThreadId = id;
            var post = _forumService.CreatePost(dto);
            if (post == null) return NotFound();
            return Ok(post);
        }
    }
}
