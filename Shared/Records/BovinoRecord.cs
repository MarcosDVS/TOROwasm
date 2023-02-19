
namespace TORO.Shared.Records;

public class BovinoRecord
{
    public BovinoRecord()
    {
        
    }
    public BovinoRecord(int idBovino, string raza, string color, string sexo, PadreRecord padre, MadreRecord madre, DateTime fechaNac, int? pesoNacer, int? costo, string? observacion)
    {
        IdBovino = idBovino;
        Raza = raza;
        Color = color;
        Sexo = sexo;
        Padre = padre;
        Madre = madre;
        FechaNac = fechaNac;
        PesoNacer = pesoNacer;
        Costo = costo;
        Observacion = observacion;
    }

    public int IdBovino { get; set; }
    public string Raza { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string Sexo { get; set; } = null!;
    public virtual PadreRecord Padre { get; set; } = default!;
    public virtual MadreRecord Madre { get; set; } = default!;
    public DateTime FechaNac { get; set; } = DateTime.Now;
    public int? PesoNacer { get; set; } = 25;
    public int? Costo { get; set; }
    public string? Observacion { get; set; }
}
