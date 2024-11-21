using System.ComponentModel.DataAnnotations;

public class PostDTO
{
    [Required(ErrorMessage = "El contenido del post es obligatorio.")]
    [StringLength(500, ErrorMessage = "El contenido no puede exceder los 500 caracteres.")]
    public string? Contenido { get; set; } // Contenido del post

    [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
    public int? UsuarioId { get; set; } // ID del usuario autor

    [Required(ErrorMessage = "El ID del hilo es obligatorio.")]
    public int HiloId { get; set; } // ID del hilo al que pertenece el post
}
