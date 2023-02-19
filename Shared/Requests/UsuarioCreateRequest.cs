using System.ComponentModel.DataAnnotations;

namespace TORO.Shared.Requests;

public class UsuarioCreateRequest
{
    [Range(1,int.MaxValue, ErrorMessage = "El rol seleccionado no es valido!.")]
    public int UsuarioRolId { get; set; }
    [
        Required(ErrorMessage = "Se debe proporcionar el nombre del Usuario"),
        MinLength(5, ErrorMessage ="El nombre debe superar 5 caracteres."),
        MaxLength(100, ErrorMessage ="El nombre no debe superar 100 caracteres.")
    ]
    public string Name { get; set; } = null!;
    [
        Required(ErrorMessage = "Se debe proporcionar el nickname del Usuario"),
        MinLength(3, ErrorMessage ="El nickname debe superar 3 caracteres."),
        MaxLength(100, ErrorMessage ="El nickname no debe superar 100 caracteres.")
    ]
    public string Nickname { get; set; } = null!;
    [
        Required(ErrorMessage = "Se debe proporcionar la contraseña del Usuario"),
        MinLength(3, ErrorMessage ="La contraseña debe superar 3 caracteres."),
        MaxLength(50, ErrorMessage ="La contraseña no debe superar 50 caracteres.")
    ]
    public string Password { get; set; } = null!;
}

public class UsuarioUpdateRequest:UsuarioCreateRequest
{
    [Required(ErrorMessage ="Se debe proporcionar el Id del Rol a modificar.")]
    public int Id { get; set; }
}