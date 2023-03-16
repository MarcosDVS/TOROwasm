using TORO.Shared.Wrapper;
using TORO.Shared.Records;
using TORO.Shared.Request;
using TORO.Shared.Routes;
using TORO.Client.Extensions;
using System.Net.Http.Json;

namespace TORO.Client.Managers;

public interface IUsuarioRolManager
{
    Task<ResultList<UsuarioRolRecord>> GetAsync();
    public async Task<Result<int>> CreateAsync( UsuarioRolCreateRequest request);

    Task<Result<UsuarioRolRecord>> GetByIdAsync(int id);
    Task<Result<int>> CreateAsync(UsuarioRolCreateRequest request);
    
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
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<UsuarioRolRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync( UsuarioRolCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(UsuarioRolRouteManager.BASE,request);
        return await response.ToResult<int>();
    }
     public async Task<Result<UsuarioRolRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(UsuarioRolRouteManager.BuilRoute(Id));
        return await response.ToResult<UsuarioRolRecord>();
    }

}