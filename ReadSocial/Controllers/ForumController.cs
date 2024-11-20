using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadSocial.Interfaces;
using System.Linq; // Asegúrate de incluir esto
using System.Threading.Tasks;

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
            var threads = await _forumService.GetAllThreadsAsync(); // Cambiado a GetAllThreadsAsync
            if (threads == null || !threads.Any()) // Cambiado a !threads.Any() para verificar si hay elementos
            {
                return NotFound("No se encontraron hilos."); // Manejo de errores
            }
            return Ok(threads);
        }
    }
}