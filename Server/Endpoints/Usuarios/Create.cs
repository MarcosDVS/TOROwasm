using Ardalis.ApiEndpoints;
using TORO.Shared.Requests;
using TORO.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using TORO.Server.Models;
using Microsoft.EntityFrameworkCore;
using TORO.Server.Context;
using TORO.Shared.Routes;

namespace TORO.Server.Endpoints.Usuario;

using Request = UsuarioCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{ 
    private readonly ITORODbContext dbContext;
    public Create(ITORODbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public ITORODbContext DbContext => dbContext;

    [HttpPost(UsuarioRouteManager.BASE)]
public override async Task<ActionResult<Respuesta>> HandleAsync (Request request, CancellationToken cancellationToken = default)
{
    try{
        #region  Validaciones
        var rol = await DbContext.Usuarios.FirstOrDefaultAsync(r => r.Nickname.ToLower() == request.Nickname.ToLower(),cancellationToken);
        if(rol != null)
            return Respuesta.Fail($"Ya existe un usuario con el correo'({request.Nickname})'.");
        #endregion
       rol = Models.Usuario.Crear(request);
        DbContext.Usuarios.Add(rol);
        await DbContext.SaveChangesAsync(cancellationToken);
        return Respuesta.Success(rol.Id);
    }
    catch( Exception e){
        return Respuesta.Fail(e.Message);
    }

}

}
