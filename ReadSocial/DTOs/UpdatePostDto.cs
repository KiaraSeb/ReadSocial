namespace ReadSocial.Dto
{public class UpdatePostDto
{
    public int Id { get; set; } // ID del post a actualizar
    public string Content { get; set; } // Nuevo contenido del post
    public string Author { get; set; } // Nuevo autor del post (opcional)
}
}