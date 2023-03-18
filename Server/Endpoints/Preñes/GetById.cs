using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TORO.Server.Context;
using TORO.Shared.Records;
using TORO.Shared.Routes;
using TORO.Shared.Wrapper;

namespace TORO.Server.Endpoints.Preñes;

using Respuesta = Result<preñesRecord>;
using Request = PreñesRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly ITORODbContext dbContext;

    public GetById(ITORODbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet(PreñesRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request,CancellationToken cancellationToken = default)
    {
        try
        {
            var rol = await dbContext.Preñeses
            .Where(r=>r.ID == request.Id)
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
