using System.ComponentModel.DataAnnotations;
using TORO.Shared.Requests;
using TORO.Shared.Records;

namespace TORO.Server.Models;

public class Preñes
{
    public Preñes()
    {
        
    }
    public Preñes(int idVaca, string razaVaca, int idToro, string razaToro, string metodoPreñes, DateTime fechaPre, DateTime pFP, string observacion)
    {
        
        IdVaca = idVaca;
        RazaVaca = razaVaca;
        IdToro = idToro;
        RazaToro = razaToro;
        MetodoPreñes = metodoPreñes;
        FechaPre = fechaPre;
        PFP = pFP;
        Observacion = observacion;
    }

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
   
    public static Preñes Crear(PreñesCreateRequest request)
    {
        return new Preñes (request.IdVaca,request.RazaVaca,request.IdToro,
        request.RazaToro,request.MetodoPreñes,request.FechaPre,request.PFP,
        request.Observacion);
    }

    public void Modificar(PreñesUpdateRequest request)
    {
        if(IdVaca != request.IdVaca) IdVaca = request.IdVaca;
        if(RazaVaca != request.RazaVaca) RazaVaca = request.RazaVaca;
        if(IdToro != request.IdToro) IdToro = request.IdToro;
        if(RazaToro != request.RazaToro) RazaToro = request.RazaToro;
        if(MetodoPreñes != request.MetodoPreñes) MetodoPreñes= request.MetodoPreñes;
        if(FechaPre != request.FechaPre) FechaPre = request.FechaPre;
        if(PFP != request.PFP) PFP = request.PFP;
        if(Observacion != request.Observacion) Observacion= request.Observacion;
        
    }
    public preñesRecord ToRecord()
    {
        return new preñesRecord(ID,IdVaca,RazaVaca,IdToro,RazaToro,MetodoPreñes,FechaPre,PFP,Observacion);
    }
    
}