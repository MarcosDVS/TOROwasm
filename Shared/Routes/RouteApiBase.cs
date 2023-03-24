
namespace TORO.Shared.Routes;

public class RouteApiBase
{
    public const string API = "/api";
    public int Id { get; set; }
    public const string IdParameter = "{Id:int}";

}
public class UsuarioRolRouteManager:RouteApiBase
{
   public const string BASE = $"{API}/roles"; 
   public const string GetById = $"{BASE}/{IdParameter}";// /api/roles/{Id:int}
   public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class UsuarioRouteManager:RouteApiBase
{
    public const string BASE = $"{API}/users";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuilRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class BovinoRouteManager:RouteApiBase
{
    public const string BASE = $"{API}/bovinos";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuilRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class PadreRouteManager:RouteApiBase
{
    public const string BASE = $"{API}/padres";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuilRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class MadreRouteManager:RouteApiBase
{
    public const string BASE = $"{API}/madres";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuilRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class ProduccionRouteManager:RouteApiBase
{
    public const string BASE = $"{API}/producciones";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuilRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class PreñesRouteManager:RouteApiBase
{
    public const string BASE = $"{API}/preñes";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuilRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}