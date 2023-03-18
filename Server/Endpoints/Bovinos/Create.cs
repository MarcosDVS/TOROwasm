using Ardalis.ApiEndpoints;
using TORO.Shared.Requests;
using TORO.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using TORO.Server.Models;
using Microsoft.EntityFrameworkCore;
using TORO.Server.Context;
using TORO.Shared.Routes;

namespace TORO.Server.Endpoints.Bovino;

using Request = BovinoCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{ 
    private readonly ITORODbContext dbContext;
    public Create(ITORODbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public ITORODbContext DbContext => dbContext;

    [HttpPost(BovinoRouteManager.BASE)]
public override async Task<ActionResult<Respuesta>> HandleAsync (Request request, CancellationToken cancellationToken = default)
{
    try{
        #region  Validaciones
        var rol = await DbContext.bovinos.FirstOrDefaultAsync(r => r.Raza.ToLower() == request.Raza.ToLower(),cancellationToken);
        if(rol != null)
            return Respuesta.Fail($"Ya existe un rol con el nombre'({request.Raza})'.");
        #endregion
       rol = Bovinos.Crear(request);
        DbContext.bovinos.Add(rol);
        await DbContext.SaveChangesAsync(cancellationToken);
        return Respuesta.Success(rol.IdBovino);
    }
    catch( Exception e){
        return Respuesta.Fail(e.Message);
    }

}

}
