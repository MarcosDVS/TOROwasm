using System;
using System.ComponentModel.DataAnnotations;
using TORO.Shared.Models;
using TORO.Shared.Records;

namespace TORO.Server.Models;

public class Produccion
{
    
     public Produccion()
     {
    
    
    }

    public Produccion(DateTime fechaProd, int vacasProd, int litrosLeche)
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
        return new Produccion (request.FechaProd, request.VacasProd, request.LitrosLeche);
    }

    public void Modificar(ProduccionUpdateRequest request)
    {
        if(FechaProd != request.FechaProd) FechaProd = request.FechaProd;
        if(VacasProd != request.VacasProd) VacasProd = request.VacasProd;
        if(LitrosLeche != request.LitrosLeche) LitrosLeche = request.LitrosLeche;
       
        
    }
    public ProduccionRecord ToRecord()
    {
        return new ProduccionRecord(ID,FechaProd,VacasProd,LitrosLeche);
    }
    
}

    
