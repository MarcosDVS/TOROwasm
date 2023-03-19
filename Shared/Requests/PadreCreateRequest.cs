using System.ComponentModel.DataAnnotations;

namespace TORO.Shared.Requests;

public class PadreCreateRequest
{
    [Required(ErrorMessage ="Se debe proporcionar el Id del Toro.")]
    public int IdPadre { get; set; }
    [Required(ErrorMessage ="Se debe proporcionar el Id del hijo del Toro.")]
    public int IdHijo { get; set; }
    public string? ColorHijo { get; set; }
    [Required(ErrorMessage ="Se debe proporcionar el sexo del hijo del Toro.")]
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;
}

public class PadreUpdateRequest: PadreCreateRequest
{
    [Required(ErrorMessage ="Se debe proporcionar el Id del padre a modificar.")]
    public int ID { get; set; }
}
