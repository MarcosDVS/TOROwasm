namespace TORO.Shared.Records;

public class preñesRecord
{
 public preñesRecord()
 {

 }

    public preñesRecord(int iD, int idVaca, string razaVaca, int idToro, string razaToro, string metodoPreñes, DateTime fechaPre, DateTime pFP, string? observacion)
    {
        ID = iD;
        IdVaca = idVaca;
        RazaVaca = razaVaca;
        IdToro = idToro;
        RazaToro = razaToro;
        MetodoPreñes = metodoPreñes;
        FechaPre = fechaPre;
        PFP = pFP;
        Observacion = observacion;
    }

    public int ID { get; set; }
    public int IdVaca { get; set; }
    public string RazaVaca { get; set; } = null!;
    public int IdToro { get; set; }
    public string RazaToro { get; set; } = null!;
    public string MetodoPreñes { get; set; } = null!;
    public DateTime FechaPre { get; set; } = DateTime.Now;
    public DateTime PFP { get; set; }
    public string? Observacion { get; set; }
    
    
}
