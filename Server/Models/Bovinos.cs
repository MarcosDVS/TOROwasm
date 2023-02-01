using System.ComponentModel.DataAnnotations;

namespace TORO.Server.Models;

public class Bovinos
{
    [Key]
    public int IdBovino { get; set; }
    public string Raza { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string Sexo { get; set; } = null!;
    public int? IdPadre { get; set; }
    public int? IdMadre { get; set; }
    public DateTime FechaNac { get; set; }= DateTime.Now;
    public int? PesoNacer { get; set; } = 25;
    public int? Costo { get; set; }
    public string? Observacion { get; set; }

}
