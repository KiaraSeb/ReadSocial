public class Usuario
{
    public int Id { get; set; } // Identificador único del usuario
    public string Nombre { get; set; } // Nombre del usuario
    public string Email { get; set; } // Email del usuario
    public string Password { get; set; } // Contraseña del usuario (debería ser manejada con cuidado)
    
    // Relación de un usuario con muchos posts
    public List<Post> Posts { get; set; } // Un usuario puede tener muchos posts

    public Usuario()
    {
        Posts = new List<Post>();
    }
}
