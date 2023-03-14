using System;
using System.ComponentModel.DataAnnotations;
using TORO.Shared.Models;

namespace TORO.Server.Models;

public class Produccion
{
    
     public Produccion()
     {
    
    
    }

    public Produccion(int iD, DateTime fechaProd, int vacasProd, int litrosLeche)
    {
        FechaProd = fechaProd;
        VacasProd = vacasProd;
        LitrosLeche = litrosLeche;
    }

    [Key]
    public int ID { get; set; }
    public DateTime FechaProd { get; set; } = DateTime.Now;
    public int VacasProd { get; set; }
    public int LitrosLeche { get; set; }

    public static Produccion Crear(ProduccionCreateRequest request)
    {
        return new Produccion (request.IdVaca);
    }

    public void Modificar(PreñesUpdateRequest request)
    {
        if(FechaProd != request.FechaProd) FechaProd = request.FechaProd;
        if(VacasProd != request.VacasProd) VacasProd = request.VacasProd;
        if(LitrosLeche != request.LitrosLeche) LitrosLeche = request.LitrosLeche;
       
        
    }
    public PadreRecord ToRecord()
    {
        return new PadreRecord(ID,FechaProd,VacasProd,LitrosLeche);
    }
    
}

    
