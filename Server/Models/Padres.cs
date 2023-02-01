using System.ComponentModel.DataAnnotations;

namespace TORO.Server.Models;

public class Padres
{
    [Key]
    public int ID { get; set; }
    public int IdPadre { get; set; }
    public int IdHijo { get; set; }
    public string? ColorHijo { get; set; }
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;
}