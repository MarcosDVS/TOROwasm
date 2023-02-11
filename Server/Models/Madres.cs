using System.ComponentModel.DataAnnotations;
using TORO.Shared.Models;

namespace TORO.Server.Models;

public class Madre
{
    [Key]
    public int ID { get; set; }
    public int IdMadre { get; set; }
    public int IdHijo { get; set; }
    public string? ColorHijo { get; set; }
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;

    public static Madre Crear(MadresRequest request)
    {
        return new Madre(){
            IdMadre = request.IdMadre,
            IdHijo = request.IdHijo,
            ColorHijo = request.ColorHijo,
            SexoHijo = request.SexoHijo,
            FechaNac = request.FechaNac
        };
    }
    public void Editar(MadresRequest request)
    {
        IdMadre = request.IdMadre;
        IdHijo = request.IdHijo;
        ColorHijo = request.ColorHijo;
        SexoHijo = request.SexoHijo;
        FechaNac = request.FechaNac;
    }
}
