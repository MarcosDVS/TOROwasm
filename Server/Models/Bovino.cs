using System.ComponentModel.DataAnnotations;
using TORO.Shared.Models;
using TORO.Shared.Records;

namespace TORO.Server.Models;

public class Bovino
{
    public Bovino()
    {
        
    }
    public Bovino(string raza, string color, string sexo, int? idPadre, int? idMadre, DateTime fechaNac, int? pesoNacer, int? costo, string? observacion)
    {
        Raza = raza;
        Color = color;
        Sexo = sexo;
        IdPadre = idPadre;
        IdMadre = idMadre;
        FechaNac = fechaNac;
        PesoNacer = pesoNacer;
        Costo = costo;
        Observacion = observacion;
    }

    [Key]
    public int IdBovino { get; set; }
    public string Raza { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string Sexo { get; set; } = null!;
    public int? IdPadre { get; set; }
    public int? IdMadre { get; set; }
    public DateTime FechaNac { get; set; } = DateTime.Now;
    public int? PesoNacer { get; set; } = 25;
    public int? Costo { get; set; }
    public string? Observacion { get; set; }
    public virtual Padre Padres { get; set; } = null!;
    public virtual Madre Madres { get; set; } = null!;

    public static Bovino Crear(BovinoCreateRequest request)
    {
        return new Bovino(request.Raza, request.Color, request.Sexo, request.IdPadre, request.IdMadre,
        request.FechaNac, request.PesoNacer, request.Costo, request.Observacion);
    }

    public void Modificar(BovinoUpdateRequest request)
    {
        if(Raza != request.Raza) Raza = request.Raza;
        if(Color != request.Color) Color = request.Color;
        if(Sexo != request.Sexo) Sexo = request.Sexo;
        if(IdPadre != request.IdPadre) IdPadre = request.IdPadre;
        if(IdMadre != request.IdMadre) IdMadre = request.IdMadre;
        if(FechaNac != request.FechaNac) FechaNac = request.FechaNac;
        if(PesoNacer != request.PesoNacer) PesoNacer = request.PesoNacer;
        if(Costo != request.Costo) Costo = request.Costo;
        if(Observacion != request.Observacion) Observacion = request.Observacion;
    }

    public BovinoRecord ToRecord()
    {
        return new BovinoRecord(IdBovino, Raza, Color, Sexo, Padres.ToRecord(), Madres.ToRecord(), 
        FechaNac, PesoNacer, Costo, Observacion);
    }
}
