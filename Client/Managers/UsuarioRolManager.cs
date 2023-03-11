using TORO.Shared.Wrapper;
using TORO.Shared.Records;
using TORO.Shared.Routes;
using TORO.Client.Extensions;

namespace TORO.Client.Managers.Client;

public interface IUsuarioRolManager
{
    Task<ResultList<UsuarioRolRecord>> GetAsync();
}

public class UsuarioRolManager : IUsuarioRolManager
{
    private readonly HttpClient httpClient;

    public UsuarioRolManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<UsuarioRolRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(UsuarioRolRouteManager.BASE);
            var resultado = await response.ToResultList<UsuarioRolRecord>();
            return resultado;;
        }
        catch (Exception e)
        {
            return ResultList<UsuarioRolRecord>.Fail(e.Message);
        }
    }
}