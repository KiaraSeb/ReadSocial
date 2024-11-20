using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadSocial.Dto;
using ReadSocial.Interfaces;

namespace ReadSocial.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IForumService _forumService;

        public PostsController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostDto dto)
        {
            var post = await _forumService.CreatePostAsync(dto);
            return CreatedAtAction(nameof(CreatePost), new { id = post.PostId }, post);
        }
    }
}
