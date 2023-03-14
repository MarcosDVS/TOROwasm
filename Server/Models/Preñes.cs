using System.ComponentModel.DataAnnotations;
using TORO.Shared.Models;

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
        if(IdRazaVaca != request.IdRazaVaca) IdRazaVaca = request.IdRazaVaca;
        if(IdToro != request.IdToro) IdToro = request.IdToro;
        if(RazaToro != request.RazaToro) RazaToro = request.RazaToro;
        if(MetodoPreñes != request.FechaNac) MetodoPreñes= request.MetodoPreñes;
        if(FechaPre != request.FechaPre) IdToro = request.FechaPre;
        if(PFP != request.PFP) PFP = request.PFP;
        if(Observacion != request.Observacion) Observacion= request.Observacion;
        
    }
    public PreñesRecord ToRecord()
    {
        return new PreñesRecord(ID,IdVaca,IdRazaVaca,IdToro,RazaToro,MetodoPreñes,FechaPre,PFP,Observacion);
    }
    
}