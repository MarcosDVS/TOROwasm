using Ardalis.ApiEndpoints;
using TORO.Shared.Requests;
using TORO.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using TORO.Server.Models;
using Microsoft.EntityFrameworkCore;
using TORO.Server.Context;
using TORO.Shared.Routes;

namespace TORO.Server.Endpoints.Preñes;

using Request = PreñesCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{ 
    private readonly ITORODbContext dbContext;
    public Create(ITORODbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public ITORODbContext DbContext => dbContext;

    [HttpPost(PreñesRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync (Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region  Validaciones
            var rol = await DbContext.Preñeses.FirstOrDefaultAsync(r => r.IdVaca == request.IdVaca, cancellationToken);
            if(rol != null)
                return Respuesta.Fail($"Ya existe un rol con el nombre'({request.IdVaca})'.");
            #endregion
        rol = EmbVaca.Crear(request);
            DbContext.Preñeses.Add(rol);
            await DbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Success(rol.IdVaca);
        }
        catch( Exception e){
            return Respuesta.Fail(e.Message);
        }

    }

}
