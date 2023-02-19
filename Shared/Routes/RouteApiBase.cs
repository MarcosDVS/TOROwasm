
namespace TORO.Shared.Routes;

public class RouteApiBase
{
    public const string API = "/api";
    public const string IdParameter = "{Id:int}";
}

public class UsuarioRolRouteManager:RouteApiBase
{
    public const string BASE = $"{API}/roles";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuilRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class UsuarioRouteManager:RouteApiBase
{
    public const string BASE = $"{API}/users";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuilRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}