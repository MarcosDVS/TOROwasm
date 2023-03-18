using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TORO.Server.Models;
using TORO.Server.Context;
using TORO.Shared.Records;
using TORO.Shared.Routes;
using TORO.Shared.Wrapper;

namespace TORO.Server.Endpoints.Produccion;
using Respuesta = ResultList<ProduccionRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly ITORODbContext dbContext;

    public Get(ITORODbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet(ProduccionRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(CancellationToken cancellationToken = default)
    {
        try{
            var roles = await dbContext.Producciones
        .Select(rol=>rol.ToRecord())
        .ToListAsync(cancellationToken);
        
        return Respuesta.Success(roles);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }
}