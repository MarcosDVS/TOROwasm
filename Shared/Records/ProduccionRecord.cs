namespace TORO.Shared.Records;

public class ProduccionRecord
{
    public ProduccionRecord()
    {
        
    }

    public ProduccionRecord(int iD, DateTime fechaProd, int vacasProd, int litrosLeche)
    {
        ID = iD;
        FechaProd = fechaProd;
        VacasProd = vacasProd;
        LitrosLeche = litrosLeche;
    }

    public int ID { get; set; }
    public DateTime FechaProd { get; set; } = DateTime.Now;
    public int VacasProd { get; set; }
    public int LitrosLeche { get; set; }

}