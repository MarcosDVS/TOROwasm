using System.ComponentModel.DataAnnotations;
using TORO.Shared.Models;
using TORO.Shared.Records;

namespace TORO.Server.Models;

public class Madre
{
    public Madre()
    {
        
    }
    public Madre(int idMadre, int idHijo, string? colorHijo, string sexoHijo, DateTime fechaNac)
    {
        IdMadre = idMadre;
        IdHijo = idHijo;
        ColorHijo = colorHijo;
        SexoHijo = sexoHijo;
        FechaNac = fechaNac;
    }

    [Key]
    public int ID { get; set; }
    public int IdMadre { get; set; }
    public int IdHijo { get; set; }
    public string? ColorHijo { get; set; }
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;
    public virtual Bovino Hijo { get; set; } = null!;

    public static Madre Crear(MadreCreateRequest request)
    {
        return new Madre(request.IdMadre, request.IdHijo, request.ColorHijo, request.SexoHijo, request.FechaNac);
    }

    public void Modificar(MadreUpdateRequest request)
    {
        if(IdMadre != request.IdMadre) IdMadre = request.IdMadre;
        if(IdHijo != request.IdHijo) IdHijo = request.IdHijo;
        if(ColorHijo != request.ColorHijo) ColorHijo = request.ColorHijo;
        if(SexoHijo != request.SexoHijo) SexoHijo = request.SexoHijo;
        if(FechaNac != request.FechaNac) FechaNac = request.FechaNac;
    }
    public MadreRecord ToRecord()
    {
        return new MadreRecord(ID, IdMadre, Hijo.ToRecord(), ColorHijo, SexoHijo, FechaNac);
    }
}
