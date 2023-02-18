using System.ComponentModel.DataAnnotations;

namespace TORO.Shared.Requests;

public class UsuarioRolUpdateRequest : UsuarioRolCreateRequest
{
    [Required(ErrorMessage ="Se debe proporcionar el Id del Rol a modificar")]
    public int Id { get; set; }
}