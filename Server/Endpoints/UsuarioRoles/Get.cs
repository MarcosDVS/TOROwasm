using Ardalis.ApiEndpoints;
using TORO.Server.Context;
using TORO.Server.Models;
using TORO.Shared.Records;
using TORO.Shared.Routes;
using TORO.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TORO.Server.Endpoints.UsuariosRoles;
using Respuesta = ResultList<UsuarioRolRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly ITORODbContext dbContext;

    public Get(ITORODbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(UsuarioRolRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(CancellationToken cancellationToken = default)
    {
       try
       {
        var roles = await dbContext.UsuariosRoles
       .Select(rol=>rol.ToRecord())
       .ToListAsync(cancellationToken);

       return Respuesta.Success(roles);
       }
       catch(Exception ex)
       {
        return Respuesta.Fail(ex.Message);
       }
    }
}
