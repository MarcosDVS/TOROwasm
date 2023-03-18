using Ardalis.ApiEndpoints;
using TORO.Shared.Requests;
using TORO.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using TORO.Server.Models;
using Microsoft.EntityFrameworkCore;
using TORO.Server.Context;
using TORO.Shared.Routes;

namespace TORO.Server.Endpoints.Produccion;

using Request = ProduccionCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{ 
    private readonly ITORODbContext dbContext;
    public Create(ITORODbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public ITORODbContext DbContext => dbContext;

    [HttpPost(ProduccionRouteManager.BASE)]
public override async Task<ActionResult<Respuesta>> HandleAsync (Request request, CancellationToken cancellationToken = default)
{
    try{
        #region  Validaciones
        var rol = await DbContext.Producciones.FirstOrDefaultAsync(r => r.FechaProd == request.FechaProd ,cancellationToken);
        if(rol != null)
            return Respuesta.Fail($"Ya existe un rol con el nombre'({request.FechaProd})'.");
        #endregion
       rol = ProdLeche.Crear(request);
        DbContext.Producciones.Add(rol);
        await DbContext.SaveChangesAsync(cancellationToken);
        return Respuesta.Success(rol.ID);
    }
    catch( Exception e){
        return Respuesta.Fail(e.Message);
    }

}

}
