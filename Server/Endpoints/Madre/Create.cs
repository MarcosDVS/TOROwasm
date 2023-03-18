using Ardalis.ApiEndpoints;
using TORO.Shared.Requests;
using TORO.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using TORO.Server.Models;
using Microsoft.EntityFrameworkCore;
using TORO.Server.Context;
using TORO.Shared.Routes;

namespace TORO.Server.Endpoints.Madre;

using Request = MadreCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{ 
    private readonly ITORODbContext dbContext;
    public Create(ITORODbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public ITORODbContext DbContext => dbContext;

    [HttpPost(MadreRouteManager.BASE)]
public override async Task<ActionResult<Respuesta>> HandleAsync (Request request, CancellationToken cancellationToken = default)
{
    try{
        #region  Validaciones
        var rol = await DbContext.Mother.FirstOrDefaultAsync(r => r.IdMadre == request.IdMadre, cancellationToken);
        if(rol != null)
            return Respuesta.Fail($"Ya existe un rol con el nombre'({request.IdMadre})'.");
        #endregion
       rol = Madres.Crear(request);
        DbContext.Mother.Add(rol);
        await DbContext.SaveChangesAsync(cancellationToken);
        return Respuesta.Success(rol.ID);
    }
    catch( Exception e){
        return Respuesta.Fail(e.Message);
    }

}

}
