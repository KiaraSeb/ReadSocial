using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/hilos")]
// [Authorize(Roles = "Administrador,Usuario")] // Dependiendo del rol, puedes permitir acceder a estos recursos
public class HiloController : ControllerBase
{
    private readonly IHiloService _hiloService;

    public HiloController(IHiloService hiloService)
    {
        _hiloService = hiloService;
    }

    // Obtener todos los hilos
    [HttpGet]
    public ActionResult<List<Hilo>> GetAllHilos()
    {
        return Ok(_hiloService.GetAll());
    }

    // Obtener un hilo por ID
    [HttpGet("{id}")]
    public ActionResult<Hilo> GetById(int id)
    {
        var hilo = _hiloService.GetById(id);
        if (hilo == null)
        {
            return NotFound("Hilo no encontrado");
        }
        return Ok(hilo);
    }

    // Crear un nuevo hilo
    [HttpPost]
    public ActionResult<Hilo> NuevoHilo(HiloDTO hiloDTO)
    {
        var nuevoHilo = _hiloService.Create(hiloDTO);
        return CreatedAtAction(nameof(GetById), new { id = nuevoHilo.Id }, nuevoHilo);
    }

    // Eliminar un hilo por ID
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var hilo = _hiloService.GetById(id);
        if (hilo == null)
        {
            return NotFound("Hilo no encontrado");
        }

        _hiloService.Delete(id);
        return NoContent();
    }

    // Actualizar un hilo
    [HttpPut("{id}")]
    public ActionResult<Hilo> UpdateHilo(int id, Hilo updatedHilo)
    {
        if (id != updatedHilo.Id)
        {
            return BadRequest("El ID del hilo en la URL no coincide con el ID del hilo en el cuerpo de la solicitud.");
        }

        var hilo = _hiloService.Update(id, updatedHilo);

        if (hilo == null)
        {
            return NotFound("Hilo no encontrado");
        }

        return Ok(hilo);
    }
}
