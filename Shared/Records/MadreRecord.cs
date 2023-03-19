
namespace TORO.Shared.Records;

public class MadreRecord
{
    public MadreRecord()
    {
        
    }

    public MadreRecord(int iD, int idMadre, string? colorHijo, string sexoHijo, DateTime fechaNac)
    {
        this.ID = iD;
        this.IdMadre = idMadre;
        this.ColorHijo = colorHijo;
        this.SexoHijo = sexoHijo;
        this.FechaNac = fechaNac;
    }

    public int ID { get; set; }
    public int IdMadre { get; set; }
    public string? ColorHijo { get; set; }
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;
}
