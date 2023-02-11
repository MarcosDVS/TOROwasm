using System.ComponentModel.DataAnnotations;
using TORO.Shared.Models;

namespace TORO.Server.Models;

public class Bovino
{
    [Key]
    public int IdBovino { get; set; }
    public string Raza { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string Sexo { get; set; } = null!;
    public int? IdPadre { get; set; }
    public virtual Padre Padres { get; set; } = null!;
    public int? IdMadre { get; set; }
    public virtual Madre Madres { get; set; } = null!;
    public DateTime FechaNac { get; set; }= DateTime.Now;
    public int? PesoNacer { get; set; } = 25;
    public int? Costo { get; set; }
    public string? Observacion { get; set; }

public static Bovino Crear(BovinosRequest request)
    {
        return new Bovinos(){
            IdBovino = request.IdBovino,
            Raza = request.Raza,
            Color = request.Color,
            Sexo = request.Sexo,
            IdPadre = request.IdPadre,
            IdMadre = request.IdMadre,
            FechaNac = request.FechaNac,
            PesoNacer = request.PesoNacer,
            Costo = request.Costo,
            Observacion = request.Observacion
        };
    }
    public void Editar(BovinosRequest request)
    {
        IdBovino = request.IdBovino;
            Raza = request.Raza;
            Color = request.Color;
            Sexo = request.Sexo;
            IdPadre = request.IdPadre;
            IdMadre = request.IdMadre;
            FechaNac = request.FechaNac;
            PesoNacer = request.PesoNacer;
            Costo = request.Costo;
            Observacion = request.Observacion;
    }
}
