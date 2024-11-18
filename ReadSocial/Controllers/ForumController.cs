using Microsoft.AspNetCore.Mvc;
using ReadSocial.Interfaces;
using ReadSocial.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thread = System.Threading.Thread;

namespace ReadSocial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly IForumService _forumService;

        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpGet("threads")]
        public async Task<ActionResult<List<Thread>>> GetThreads()
        {
            var threads = await _forumService.GetThreads();
            return Ok(threads);
        }

        [HttpPost("threads")]
        public async Task<ActionResult<Thread>> CreateThread([FromBody] CreateThreadDto dto)
        {
            var thread = await _forumService.CreateThreadAsync(dto);
            return CreatedAtAction(nameof(GetThreads), new { id = thread.Id }, thread);
        }
    }
}
