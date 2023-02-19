
namespace TORO.Shared.Records;

public class MadreRecord
{
    public MadreRecord()
    {
        
    }

    public MadreRecord(int iD, int idMadre, BovinoRecord hijo, string? colorHijo, string sexoHijo, DateTime fechaNac)
    {
        ID = iD;
        IdMadre = idMadre;
        Hijo = hijo;
        ColorHijo = colorHijo;
        SexoHijo = sexoHijo;
        FechaNac = fechaNac;
    }

    public int ID { get; set; }
    public int IdMadre { get; set; }
    public BovinoRecord Hijo { get; set; } = default!;
    public string? ColorHijo { get; set; }
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;
}
