using System.ComponentModel.DataAnnotations;
using TORO.Shared.Models;
using TORO.Shared.Records;

namespace TORO.Server.Models;

public class Padre
{
    public Padre()
    {
        
    }
    public Padre(int idPadre, int idHijo, string? colorHijo, string sexoHijo, DateTime fechaNac)
    {
        IdPadre = idPadre;
        IdHijo = idHijo;
        ColorHijo = colorHijo;
        SexoHijo = sexoHijo;
        FechaNac = fechaNac;
    }
    [Key]
    public int ID { get; set; }
    public int IdPadre { get; set; }
    public int IdHijo { get; set; }
    public virtual Bovino Hijo { get; set; } = null!;
    public string? ColorHijo { get; set; }
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;

    public static Padre Crear(PadreCreateRequest request)
    {
        return new Padre(request.IdPadre, request.IdHijo, request.ColorHijo, request.SexoHijo, request.FechaNac);
    }

    public void Modificar(PadreUpdateRequest request)
    {
        if(IdPadre != request.IdPadre) IdPadre = request.IdPadre;
        if(IdHijo != request.IdHijo) IdHijo = request.IdHijo;
        if(ColorHijo != request.ColorHijo) ColorHijo = request.ColorHijo;
        if(SexoHijo != request.SexoHijo) SexoHijo = request.SexoHijo;
        if(FechaNac != request.FechaNac) FechaNac = request.FechaNac;
    }

    public PadreRecord ToRecord()
    {
        return new PadreRecord(ID, IdPadre, Hijo.ToRecord(), ColorHijo, SexoHijo, FechaNac);
    }
}