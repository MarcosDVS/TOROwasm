using Ardalis.ApiEndpoints;
using TORO.Server.Context;
using TORO.Server.Models;
using TORO.Shared.Records;
using TORO.Shared.Routes;
using TORO.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TORO.Server.Endpoints.UsuariosRoles;
using Respuesta = Result<UsuarioRolRecord>;
using Request = UsuarioRolRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly ITORODbContext dbContext;

    public GetById(ITORODbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(UsuarioRolRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request,CancellationToken cancellationToken = default)
    {
       try
       {
        var rol = await dbContext.UsuariosRoles
        .Where(r=>r.Id == request.Id)
       .Select(rol=>rol.ToRecord())
       .FirstOrDefaultAsync(cancellationToken);

       if(rol==null)
        return Respuesta.Fail($"No fue posible encontrar el rol '{request.Id}'");

        return Respuesta.Success(rol);
       }
       catch(Exception ex)
       {
        return Respuesta.Fail(ex.Message);
       }
    }
}
