using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadSocial.Interfaces;

namespace ReadSocial.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly IForumService _forumService;

        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpGet]
        public async Task<IActionResult> GetThreads()
        {
            var threads = await _forumService.GetThreadsAsync();
            return Ok(threads);
        }
    }
}
