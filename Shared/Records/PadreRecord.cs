
namespace TORO.Shared.Records;

public class PadreRecord
{
    public PadreRecord()
    {
        
    }
    public PadreRecord(int iD, int idPadre, int idHijo, string? colorHijo, string sexoHijo, DateTime fechaNac)
    {
        this.ID = iD;
        this.IdPadre = idPadre;
        this.IdHijo = IdHijo;
        this.ColorHijo = colorHijo;
        this.SexoHijo = sexoHijo;
        this.FechaNac = fechaNac;
    }

    public int ID { get; set; }
    public int IdPadre { get; set; }
    public int IdHijo { get; set; }
    public string? ColorHijo { get; set; }
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;
}