using System.ComponentModel.DataAnnotations;

namespace TORO.Shared.Models;

public class PadreCreateRequest
{
    public int IdPadre { get; set; }
    public int IdHijo { get; set; }
    public string? ColorHijo { get; set; }
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;
}

public class PadreUpdateRequest: PadreCreateRequest
{
    [Required(ErrorMessage ="Se debe proporcionar el Id del padre a modificar.")]
    public int ID { get; set; }
}
