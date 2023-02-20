using System.ComponentModel.DataAnnotations;

namespace TORO.Shared.Models;

public class PreñesCreateRequest
{
    public int IdVaca { get; set; }
    public string RazaVaca { get; set; } = null!;
    public int IdToro { get; set; }
    public string RazaToro { get; set; } = null!;
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