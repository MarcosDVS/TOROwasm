
namespace TORO.Shared.Records;

public class PadreRecord
{
    public PadreRecord()
    {
        
    }
    public PadreRecord(int iD, int idPadre, BovinoRecord hijo, string? colorHijo, string sexoHijo, DateTime fechaNac)
    {
        ID = iD;
        IdPadre = idPadre;
        Hijo = hijo;
        ColorHijo = colorHijo;
        SexoHijo = sexoHijo;
        FechaNac = fechaNac;
    }

    public int ID { get; set; }
    public int IdPadre { get; set; }
    public BovinoRecord Hijo { get; set; } = default!;
    public string? ColorHijo { get; set; }
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;
}