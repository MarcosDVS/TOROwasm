using System.ComponentModel.DataAnnotations;
using TORO.Shared.Models;
using TORO.Shared.Records;

namespace TORO.Server.Models;

public class Madre
{
    [Key]
    public int ID { get; set; }
    public int IdMadre { get; set; }
    public int IdHijo { get; set; }
    public virtual Bovino Hijo { get; set; } = null!;
    public string? ColorHijo { get; set; }
    public string SexoHijo { get; set; } = null!;
    public DateTime FechaNac { get; set; } = DateTime.Now;

    public MadreRecord ToRecord()
    {
        return new MadreRecord(ID, IdMadre, Hijo.ToRecord(), ColorHijo, SexoHijo, FechaNac);
    }
}
