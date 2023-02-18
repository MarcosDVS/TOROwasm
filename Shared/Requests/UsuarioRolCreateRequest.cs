using System.ComponentModel.DataAnnotations;

namespace TORO.Shared.Requests;

public class UsuarioRolCreateRequest
{
    [
        Required(ErrorMessage = "Se debe proporcionar el nombre del rol"),
        MinLength(5, ErrorMessage ="El nombre debe superar 5 caracteres"),
        MaxLength(100, ErrorMessage ="El nombre no debe superar 100 caracteres")
    ]
    public string Nombre { get; set; } = null!;
    public bool PermisoCrear { get; set; }
    public bool PermisoEditar { get; set; }
    public bool PermisoEliminar { get; set; }
}
