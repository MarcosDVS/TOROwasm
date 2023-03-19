namespace TORO.Shared.Records;

public class ProduccionRecord
{
    public ProduccionRecord()
    {
        
    }

    public ProduccionRecord(int iD, DateTime fechaProd, int vacasProd, int litrosLeche)
    {
        this.ID = iD;
        this.FechaProd = fechaProd;
        this.VacasProd = vacasProd;
        this.LitrosLeche = litrosLeche;
    }

    public int ID { get; set; }
    public DateTime FechaProd { get; set; } = DateTime.Now;
    public int VacasProd { get; set; }
    public int LitrosLeche { get; set; }

}