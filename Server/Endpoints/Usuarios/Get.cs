using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TORO.Server.Models;
using TORO.Server.Context;
using TORO.Shared.Records;
using TORO.Shared.Routes;
using TORO.Shared.Wrapper;

namespace TORO.Server.Endpoints.Usuario;
using Respuesta = ResultList<UsuarioRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly ITORODbContext dbContext;

    public Get(ITORODbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet(UsuarioRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(CancellationToken cancellationToken = default)
    {
        try{
            var roles = await dbContext.Users
        .Select(rol=>rol.ToRecord())
        .ToListAsync(cancellationToken);
        
        return Respuesta.Success(roles);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }
}