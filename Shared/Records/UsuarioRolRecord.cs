
namespace TORO.Shared.Records;

public class UsuarioRolRecord
{
    public UsuarioRolRecord(int id, string nombre, bool permisoCrear, bool permisoEditar, bool permisoEliminar)
    {
        Id = id;
        Nombre = nombre;
        PermisoCrear = permisoCrear;
        PermisoEditar = permisoEditar;
        PermisoEliminar = permisoEliminar;
    }

    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public bool PermisoCrear { get; set; }
    public bool PermisoEditar { get; set; }
    public bool PermisoEliminar { get; set; }
}