using Microsoft.EntityFrameworkCore;

public class PostDbService : IPostService
{
    private readonly ForoDbContext _context;

    public PostDbService(ForoDbContext context)
    {
        _context = context;
    }

    // Obtener todos los posts de un hilo específico
    public IEnumerable<Post> GetAllByHiloId(int hiloId)
    {
        return _context.Posts
            .Where(p => p.HiloId == hiloId)
            .AsNoTracking() // No se realiza un seguimiento de cambios
            .ToList();
    }

    // Obtener un post por su ID
    public Post? GetById(int id)
    {
        return _context.Posts
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == id);
    }

    // Crear un nuevo post
    public Post Create(PostDTO postDto)
    {
        var post = new Post
        {
            Contenido = postDto.Contenido,
            FechaCreacion = DateTime.UtcNow, // Ajusta según sea necesario
            HiloId = postDto.HiloId,
            UsuarioId = postDto.UsuarioId
        };

        _context.Posts.Add(post);
        _context.SaveChanges();

        return post;
    }

    // Actualizar un post existente
    public Post Update(int id, Post post)
    {
        var existingPost = _context.Posts.FirstOrDefault(p => p.Id == id);

        if (existingPost == null)
        {
            return null; // O lanzar una excepción si prefieres
        }

        existingPost.Contenido = post.Contenido;
        existingPost.FechaCreacion = post.FechaCreacion;
        existingPost.HiloId = post.HiloId;
        existingPost.UsuarioId = post.UsuarioId;

        _context.Posts.Update(existingPost);
        _context.SaveChanges();

        return existingPost;
    }

    // Eliminar un post por su ID
    public bool Delete(int id)
    {
        var post = _context.Posts.FirstOrDefault(p => p.Id == id);

        if (post == null)
        {
            return false; // No se encontró el post
        }

        _context.Posts.Remove(post);
        _context.SaveChanges();

        return true;
    }
}
