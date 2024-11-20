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
        public async Task<ActionResult<List<ThreadDto>>> GetAllThreads()
        {
            var threads = await _forumService.GetAllThreadsAsync(); 
            return Ok(threads); // Retorna todos los hilos en la base de datos
        }

        // Obtener un hilo por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ThreadDto>> GetThreadById(int id)
        {
            var thread = await _forumService.GetThreadByIdAsync(id); 
            if (thread == null)
            {
                return NotFound("Hilo no encontrado");
            }
            return Ok(thread); // Retorna el hilo con el ID proporcionado
        }

        // Crear un nuevo hilo
        [HttpPost]
        public async Task<ActionResult<ThreadDto>> CreateThread([FromBody] CreateThreadDto dto)
        {
            if (dto == null)
            {
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");
            }

            // Llamada al servicio para crear el hilo
            var createdThread = await _forumService.CreateThreadAsync(dto);

            // Retornar el hilo creado con una URL de referencia al nuevo hilo
            return CreatedAtAction(nameof(GetThreadById), new { id = createdThread.Id }, createdThread);
        }
    }
}
