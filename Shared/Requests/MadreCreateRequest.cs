using System.ComponentModel.DataAnnotations;

namespace TORO.Shared.Models;

public class MadreCreateRequest
{
    public int IdMadre { get; set; }
    public int IdHijo { get; set; }
    public string? ColorHijo { get; set; }
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;
}

public class MadreUpdateRequest:MadreCreateRequest
{
    [Required(ErrorMessage ="Se debe proporcionar el Id de la madre a modificar.")]
    public int ID { get; set; }
}