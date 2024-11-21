using System.ComponentModel.DataAnnotations;

public class HiloDTO
{
    [Required(ErrorMessage = "El título es obligatorio.")]
    [MaxLength(100, ErrorMessage = "El título no puede exceder los 100 caracteres.")]
    public string Titulo { get; set; }

    [MaxLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
    public string? Descripcion { get; set; }

    public int? UsuarioId { get; set; }
}
