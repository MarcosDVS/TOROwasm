namespace TORO.Shared.Models;

public class PreñesRequest
{
    public int ID { get; set; }
    public int IdVaca { get; set; }
    public string RazaVaca { get; set; } = null!;
    public int IdToro { get; set; }
    public string RazaToro { get; set; } = null!;
    public string MetodoPreñes { get; set; } = null!;
    public DateTime FechaPre { get; set; } = DateTime.Now;
    public DateTime PFP { get; set; }
    public string? Observacion { get; set; }
}
