using System.ComponentModel.DataAnnotations;
using TORO.Shared.Models;

namespace TORO.Server.Models;

public class Preñes
{
    [Key]
    public int ID { get; set; }
    public int IdVaca { get; set; }
    public string RazaVaca { get; set; } = null!;
    public int IdToro { get; set; }
    public string RazaToro { get; set; } = null!;
    public string MetodoPreñes { get; set; } = null!;
    public DateTime FechaPre { get; set; } = DateTime.Now;
    public DateTime PFP { get; set; }
    public string? Observacion { get; set; }
    
    public static Preñes Crear(PreñesRequest request)
    {
        return new Preñes(){
            IdVaca = request.IdVaca,
            RazaVaca = request.RazaVaca,
            IdToro = request.IdToro,
            RazaToro = request.RazaToro,
            MetodoPreñes = request.MetodoPreñes,
            FechaPre = request.FechaPre,
            PFP = request.PFP,
            Observacion = request.Observacion
        };
    }
    public void Editar(PreñesRequest request)
    {
        IdVaca = request.IdVaca;
        RazaVaca = request.RazaVaca;
        IdToro = request.IdToro;
        RazaToro = request.RazaToro;
        MetodoPreñes = request.MetodoPreñes;
        FechaPre = request.FechaPre;
        PFP = request.PFP;
        Observacion = request.Observacion;
    }
}