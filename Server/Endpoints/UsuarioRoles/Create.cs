using Ardalis.ApiEndpoints;
using TORO.Shared.Requests;
using TORO.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using TORO.Server.Models;
using Microsoft.EntityFrameworkCore;
using TORO.Server.Context;
using TORO.Shared.Routes;

namespace TORO.Server.Endpoints.UsuarioRoles;


using Request = UsuarioRolCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithoutRequest<Request>.WithActionResult<Respuesta>
{
    private readonly ITORODbContext dbContext;
    public Create(ITORODbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpPost(UsuarioRolRouteManager.BASE)]
public override async Task<ActionResult<Respuesta>> HandleAsync (Request request, CancellationToken cancellationToken = default)
{
    try{
        #region  Validaciones
        var rol = await dbContext.UsuariosRoles.FirstOrDefaultAsync(r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
        if(rol != null)
            return Respuesta.Fail($"Ya existe un rol con el nombre'({request.Nombre})'.");
        #endregion
        rol = UsuarioRol.Crear(request);
        dbContext.UsuariosRoles.Add(rol);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Respuesta.Success(rol.Id);
    }
    catch( Exception e){
        return Respuesta.Fail(e.Message);
    }

}

}
