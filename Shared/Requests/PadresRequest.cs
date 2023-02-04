namespace TORO.Shared.Models;

public class PadresRequest
{
    public int ID { get; set; }
    public int IdPadre { get; set; }
    public int IdHijo { get; set; }
    public string? ColorHijo { get; set; }
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;
}
