using System.ComponentModel.DataAnnotations;
using TORO.Shared.Models;

namespace TORO.Server.Models;

public class Padre
{
    [Key]
    public int ID { get; set; }
    public int IdPadre { get; set; }
    public int IdHijo { get; set; }
    public string? ColorHijo { get; set; }
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;

    public static Padre Crear(PadresRequest request)
    {
        return new Padre(){
            IdPadre = request.IdPadre,
            IdHijo = request.IdHijo,
            ColorHijo = request.ColorHijo,
            SexoHijo = request.SexoHijo,
            FechaNac = request.FechaNac
        };
    }
    public void Editar(PadresRequest request)
    {
        IdPadre = request.IdPadre;
        IdHijo = request.IdHijo;
        ColorHijo = request.ColorHijo;
        SexoHijo = request.SexoHijo;
        FechaNac = request.FechaNac;
    }
}