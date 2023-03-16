using System.Threading;
using System.Reflection.Metadata;
using System;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using TORO.Shared.Records;
using TORO.Shared.Requests;
using TORO.shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using TORO.Server.Models;
using Microsoft.EntityFrameworkCore;


namespace TORO.Server.Endpoints.UsuarioRoles;


using Request = UsuarioRolCreateRequest;
using Respuesta = Result<int>;

public class Create :EndpointsBaseAsync.WithoutRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpPost(UsuarioRouteManager.BASE)]
public override  async Task<ActionResult<Respuesta>> HandleAsync (Request request, CancellationToken cancellationToken = default)
{
    try{
        #region  Validaciones
        var rol = await dbContext.UsuariosRoles.FirstOrDefaultAsync(r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
        if(rol != null)
            return Respuesta.Fail($"Ya existe un rol con el nombre'({request.Nombre})'.");
        #endregion
        rol = UsuarioRol.Crear(request);
        dbContext.UsuarioRoles.Add(rol);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Respuesta.Success(rol.Id);
    }
    catch( Exception e){
        return Respuesta.Fail(e.Message);
    }

}

}
