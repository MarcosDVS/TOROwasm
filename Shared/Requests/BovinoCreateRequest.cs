using System.ComponentModel.DataAnnotations;

namespace TORO.Shared.Requests;

public class BovinoCreateRequest
{
    [Required(ErrorMessage ="Se debe proporcionar la raza del Bovino.")]
    public string Raza { get; set; } = null!;
    [Required(ErrorMessage ="Se debe proporcionar el Color del Bovino.")]
    public string Color { get; set; } = null!;
    [Required(ErrorMessage ="Se debe proporcionar el sexo del Bovino.")]
    public string Sexo { get; set; } = null!;
    public int? IdPadre { get; set; }
    public int? IdMadre { get; set; }
    public DateTime FechaNac { get; set; }= DateTime.Now;
    public int? PesoNacer { get; set; }
    public int? Costo { get; set; }
    public string? Observacion { get; set; }
}

public class BovinoUpdateRequest : BovinoCreateRequest
{
    [Required(ErrorMessage ="Se debe proporcionar el Id del Bovino a modificar.")]
    public int IdBovino { get; set; }
}