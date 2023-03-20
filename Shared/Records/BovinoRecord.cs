
namespace TORO.Shared.Records;

public class BovinoRecord
{
    public BovinoRecord()
    {
        
    }
    public BovinoRecord(int idBovino, string raza, string color, string sexo, PadreRecord padre, MadreRecord madre, DateTime fechaNac, int? pesoNacer, int? costo, string? observacion)
    {
        this.IdBovino = idBovino;
        this.Raza = raza;
        this.Color = color;
        this.Sexo = sexo;
        this.Padre = padre;
        this.Madre = madre;
        this.FechaNac = fechaNac;
        this.PesoNacer = pesoNacer;
        this.Costo = costo;
        this.Observacion = observacion;
    }

    public int IdBovino { get; set; }
    public string Raza { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string Sexo { get; set; } = null!;
    public PadreRecord Padre { get; set; } = null!;
    public MadreRecord Madre { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;
    public int? PesoNacer { get; set; } = 25;
    public int? Costo { get; set; }
    public string? Observacion { get; set; }
}
