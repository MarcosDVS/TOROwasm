using System.ComponentModel.DataAnnotations;
using TORO.Shared.Requests;
using TORO.Shared.Records;

namespace TORO.Server.Models;

public class Bovinos
{
    public Bovinos()
    {
        
    }
    public Bovinos(string raza, string color, string sexo, int? idPadre, int? idMadre, DateTime fechaNac, int? pesoNacer, int? costo, string? observacion)
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

    #region propiedades
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
    public virtual Padres padre { get; set; } = null!;
    public virtual Madres Mother { get; set; } = null!;
    #endregion

    #region Funciones
    public static Bovinos Crear(BovinoCreateRequest request)
    {
        return new Bovinos(
            request.Raza,
            request.Color,
            request.Sexo,
            request.IdPadre,
            request.IdMadre,
            request.FechaNac,
            request.PesoNacer,
            request.Costo,
            request.Observacion
        );
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
    #endregion
    
    public BovinoRecord ToRecord()
    {
        return new BovinoRecord(IdBovino, Raza, Color, Sexo, padre.ToRecord(), Mother.ToRecord(), 
        FechaNac, PesoNacer, Costo, Observacion);
    }
}
