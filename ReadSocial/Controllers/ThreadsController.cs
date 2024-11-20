using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadSocial.Dto;
using ReadSocial.Interfaces;
using System.Threading.Tasks;

namespace ReadSocial.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ThreadsController : ControllerBase
    {
        private readonly IForumService _forumService;

        public ThreadsController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateThread([FromBody] CreateThreadDto dto) // Asegúrate de que el DTO se reciba del cuerpo de la solicitud
        {
            if (dto == null)
            {
                return BadRequest("El cuerpo de la solicitud no puede estar vacío."); // Validación del cuerpo
            }

            var thread = await _forumService.CreateThreadAsync(dto);
            if (thread == null)
            {
                return StatusCode(500, "Error al crear el hilo."); // Manejo de errores
            }

            return CreatedAtAction(nameof(CreateThread), new { id = thread.ThreadId }, thread);
        }
    }
}