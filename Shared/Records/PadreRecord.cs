
namespace TORO.Shared.Records;

public class PadreRecord
{
    public PadreRecord()
    {
        
    }
    public PadreRecord(int iD, int idPadre, string? colorHijo, string sexoHijo, DateTime fechaNac)
    {
        this.ID = iD;
        this.IdPadre = idPadre;
        this.ColorHijo = colorHijo;
        this.SexoHijo = sexoHijo;
        this.FechaNac = fechaNac;
    }

    public int ID { get; set; }
    public int IdPadre { get; set; }
    public string? ColorHijo { get; set; }
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;
}