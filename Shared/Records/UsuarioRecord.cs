
namespace TORO.Shared.Records;

public class UsuarioRecord
{
    public UsuarioRecord()
    {
        
    }
    public UsuarioRecord(int id, UsuarioRolRecord usuarioRol, string name, string nickname, string password)
    {
        this.Id = id;
        this.UsuarioRol = usuarioRol;
        this.Name = name;
        this.Nickname = nickname;
        this.Password = password;
    }

    public int Id { get; set; }
    public virtual UsuarioRolRecord UsuarioRol { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Nickname { get; set; } = null!;
    public string Password { get; set; } = null!;
}
