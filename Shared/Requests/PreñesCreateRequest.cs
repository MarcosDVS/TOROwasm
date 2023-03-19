using System.ComponentModel.DataAnnotations;

namespace TORO.Shared.Requests;

public class PreñesCreateRequest
{
    [Required(ErrorMessage ="Se debe proporcionar el Id de la vaca.")]
    public int IdVaca { get; set; }
    [Required(ErrorMessage ="Se debe proporcionar la raza de la vaca.")]
    public string RazaVaca { get; set; } = null!;
    [Required(ErrorMessage ="Se debe proporcionar el Id del Toro.")]
    public int IdToro { get; set; }
    [Required(ErrorMessage ="Se debe proporcionar la raza del Toro.")]
    public string RazaToro { get; set; } = null!;
    [Required(ErrorMessage ="Se debe proporcionar el metodo de preñes.")]
    public string MetodoPreñes { get; set; } = null!;
    public DateTime FechaPre { get; set; } = DateTime.Now;
    public DateTime PFP { get; set; }
    public string? Observacion { get; set; }
}

public class PreñesUpdateRequest:PreñesCreateRequest
{
    [Required(ErrorMessage ="Se debe proporcionar el Id del embarazo a modificar.")]
    public int ID { get; set; }
}