using System.ComponentModel.DataAnnotations;
using TORO.Shared.Records;
using TORO.Shared.Requests;

namespace TORO.Server.Models;

public class Usuarios
{
    public Usuarios()
    {
        
    }
    public Usuarios(int usuarioRolId, string name, string nickname, string password)
    {
        UsuarioRolId = usuarioRolId;
        Name = name;
        Nickname = nickname;
        Password = password;
    }

    [Key]
    public int Id { get; set; }
    public int UsuarioRolId { get; set; }
    public string Name { get; set; } = null!;
    public string Nickname { get; set; } = null!;
    public string Password { get; set; } = null!;
    public UsuarioRol UsuarioRol { get; set; } = default!;

    public static Usuarios Crear(UsuarioCreateRequest request) 
    {
        return new Usuarios(request.UsuarioRolId, request.Name, request.Nickname, request.Password);
    }

    public void Modificar(UsuarioUpdateRequest request)
    {
        if(Name != request.Name) Name = request.Name;
        if(UsuarioRolId != request.UsuarioRolId) UsuarioRolId = request.UsuarioRolId;
        if(Nickname != request.Nickname) Nickname = request.Nickname;
        if(Password != request.Password) Password = request.Password;
    }

    public UsuarioRecord ToRecord()
    {
        return new UsuarioRecord(Id, UsuarioRol.ToRecord(), Name, Nickname, Password);
    }
}
