using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadSocial.Dto;
using ReadSocial.Interfaces;
using System.Threading.Tasks;

namespace ReadSocial.Controllers
{
    [ApiController]
    [Authorize] // Asegúrate de que el usuario esté autenticado
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IForumService _forumService;

        public PostsController(IForumService forumService)
        {
            _forumService = forumService;
        }

        // Método para crear un nuevo post
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto dto) // Asegúrate de que el DTO se reciba del cuerpo de la solicitud
        {
            if (dto == null)
            {
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");
            }

            var post = await _forumService.CreatePostAsync(dto);
            if (post == null)
            {
                return StatusCode(500, "Error al crear el post."); // Manejo de errores
            }

            return CreatedAtAction(nameof(CreatePost), new { id = post.PostId }, post);
        }
    }
}