using System.ComponentModel.DataAnnotations;
using TORO.Shared.Records;
using TORO.Shared.Requests;

namespace TORO.Server.Models;

public class UsuarioRol
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public bool PermisoCrear { get; set; }
    public bool PermisoEditar { get; set; }
    public bool PermisoEliminar { get; set; }
    
    public static UsuarioRol Crear(UsuarioRolCreateRequest request)
    {
        return new UsuarioRol()
        {
            Nombre = request.Nombre,
            PermisoCrear = request.PermisoCrear,
            PermisoEditar = request.PermisoEditar,
            PermisoEliminar = request.PermisoEliminar
        };
    }
    public void Modificar(UsuarioRolUpdateRequest request)
    {
        if(Nombre != request.Nombre)
            Nombre = request.Nombre;
        if(PermisoCrear != request.PermisoCrear)
            PermisoCrear = request.PermisoCrear;
        if(PermisoEditar != request.PermisoEditar)
            PermisoEditar = request.PermisoEditar;
        if(PermisoEliminar != request.PermisoEliminar)
            PermisoEliminar = request.PermisoEliminar;
    }

public UsuarioRolRecord ToRecord()
{
    return new UsuarioRolRecord(Id, Nombre, PermisoCrear, PermisoEditar, PermisoEliminar);
}
}