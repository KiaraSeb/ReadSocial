using Microsoft.AspNetCore.Mvc;
using ReadSocial.Dto;
using ReadSocial.Interfaces;

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

        [HttpPost]
        public async Task<IActionResult> CreateThread(CreateThreadDto dto)
        {
            var thread = await _forumService.CreateThreadAsync(dto);
            return CreatedAtAction(nameof(CreateThread), new { id = thread.ThreadId }, thread);
        }
    }
}
