using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadSocial.Dto;
using ReadSocial.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadSocial.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/threads")]
    public class ThreadsController : ControllerBase
    {
        private readonly IForumService _forumService;

        public ThreadsController(IForumService forumService)
        {
            _forumService = forumService;
        }

        // Obtener todos los hilos
        [HttpGet]
        public async Task<ActionResult<List<ThreadDto>>> GetAllThreads() // Cambiado a Task<ActionResult<List<ThreadDto>>>
        {
            var threads = await _forumService.GetAllThreadsAsync(); // Cambiado a GetAllThreadsAsync
            return Ok(threads);
        }

        // Obtener un hilo por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ThreadDto>> GetThreadById(int id) // Cambiado a Task<ActionResult<ThreadDto>>
        {
            var thread = await _forumService.GetThreadByIdAsync(id); // Cambiado a GetThreadByIdAsync
            if (thread == null)
            {
                return NotFound("Hilo no encontrado");
            }
            return Ok(thread);
        }

        // Crear un nuevo hilo
        [HttpPost]
        public async Task<ActionResult<ThreadDto>> CreateThread([FromBody] CreateThreadDto dto)
        {
            if (dto == null)
            {
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");
            }

            var createdThread = await _forumService.CreateThreadAsync(dto);
            return CreatedAtAction(nameof(GetThreadById), new { id = createdThread.Id }, createdThread);
        }
    }
}