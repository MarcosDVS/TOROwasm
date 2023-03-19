namespace TORO.Shared.Records;

public class preñesRecord
{
    public preñesRecord()
    {

    }

    public preñesRecord(int iD, int idVaca, string razaVaca, int idToro, string razaToro, string metodoPreñes, DateTime fechaPre, DateTime pFP, string? observacion)
    {
        this.ID = iD;
        this.IdVaca = idVaca;
        this.RazaVaca = razaVaca;
        this.IdToro = idToro;
        this.RazaToro = razaToro;
        this.MetodoPreñes = metodoPreñes;
        this.FechaPre = fechaPre;
        this.PFP = pFP;
        this.Observacion = observacion;
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
