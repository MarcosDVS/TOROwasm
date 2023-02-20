using System.ComponentModel.DataAnnotations;
using TORO.Shared.Models;

namespace TORO.Server.Models;

public class Produccion
{
    [Key]
    public int ID { get; set; }
    public DateTime FechaProd { get; set; } = DateTime.Now;
    public int VacasProd { get; set; }
    public int LitrosLeche { get; set; }

    
}