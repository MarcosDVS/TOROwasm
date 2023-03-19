using System.ComponentModel.DataAnnotations;

namespace TORO.Shared.Requests;

public class MadreCreateRequest
{
    [Required(ErrorMessage ="Se debe proporcionar el Id de la Vaca.")]
    public int IdMadre { get; set; }
    [Required(ErrorMessage ="Se debe proporcionar el Id del hijo la Vaca.")]
    public int IdHijo { get; set; }
    public string? ColorHijo { get; set; }
    [Required(ErrorMessage ="Se debe proporcionar el sexo del hijo de la vaca.")]
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;
}

public class MadreUpdateRequest:MadreCreateRequest
{
    [Required(ErrorMessage ="Se debe proporcionar el Id de la madre a modificar.")]
    public int ID { get; set; }
}