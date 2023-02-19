using System.ComponentModel.DataAnnotations;
using TORO.Shared.Models;
using TORO.Shared.Records;

namespace TORO.Server.Models;

public class Padre
{
    [Key]
    public int ID { get; set; }
    public int IdPadre { get; set; }
    public int IdHijo { get; set; }
    public virtual Bovino Hijo { get; set; } = null!;
    public string? ColorHijo { get; set; }
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;


    public PadreRecord ToRecord()
    {
        return new PadreRecord(ID, IdPadre, Hijo.ToRecord(), ColorHijo, SexoHijo, FechaNac);
    }
}