public interface IPostService
{
    IEnumerable<Post> GetAllByHiloId(int hiloId); // Obtiene todos los posts de un hilo específico
    Post? GetById(int id); // Obtiene un post por su ID
    Post Create(PostDTO postDto); // Crea un nuevo post
    Post Update(int id, Post post); // Actualiza un post existente
    bool Delete(int id); // Elimina un post por su ID
}
