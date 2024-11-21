using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/posts")]
// [Authorize(Roles = "Administrador,Usuario")] // Dependiendo del rol, puedes permitir acceder a estos recursos
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    // Obtener un post por ID
    [HttpGet("{id}")]
    public ActionResult<Post> GetById(int id)
    {
        var post = _postService.GetById(id);
        if (post == null)
        {
            return NotFound("Post no encontrado");
        }
        return Ok(post);
    }

    // Crear un nuevo post
    [HttpPost]
    public ActionResult<Post> NuevoPost(PostDTO postDTO)
    {
        var nuevoPost = _postService.Create(postDTO);
        return CreatedAtAction(nameof(GetById), new { id = nuevoPost.Id }, nuevoPost);
    }

    // Eliminar un post por ID
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var post = _postService.GetById(id);
        if (post == null)
        {
            return NotFound("Post no encontrado");
        }

        _postService.Delete(id);
        return NoContent();
    }

    // Actualizar un post
    [HttpPut("{id}")]
    public ActionResult<Post> UpdatePost(int id, Post post)
    {
        if (id != post.Id)
        {
            return BadRequest("El ID del post en la URL no coincide con el ID del post en el cuerpo de la solicitud.");
        }

        var post1 = _postService.Update(id, post);

        if (post1 == null)
        {
            return NotFound("Post no encontrado");
        }

        return Ok(post1);
    }
}
