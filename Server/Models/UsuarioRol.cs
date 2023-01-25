using System.ComponentModel.DataAnnotations;

namespace TORO.Server.Models;

public class UsuarioRol
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public bool PermisoCrar { get; set; }
    public bool PermisoEditar { get; set; }
    public bool PermisoEliminar { get; set; }
    public virtual ICollection<UsuarioRol>? Usuarios { get; set; }
}