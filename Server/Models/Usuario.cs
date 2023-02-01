using System.ComponentModel.DataAnnotations;
using TORO.Shared.Requests;

namespace TORO.Server.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    public int UsuarioRolId { get; set; }
    public UsuarioRol UsuarioRol { get; set; } = default!;
    public string Name { get; set; } = null!;
    public string Nickname { get; set; } = null!;
    public string Password { get; set; } = null!;

    public static Usuario Crear(UsuarioRequest request)
    {
        return new Usuario(){
            UsuarioRolId = request.UsuarioRolId,
            Name = request.Name,
            Nickname = request.Nickname,
            Password = request.Password
        };
    }
    public void Editar(UsuarioRequest request)
    {
        UsuarioRolId = request.UsuarioRolId;
        Name = request.Name;
        Nickname = request.Nickname;
        //Password = request.Password;
    }
}
