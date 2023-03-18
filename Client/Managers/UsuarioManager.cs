using TORO.Shared.Wrapper;
using TORO.Shared.Records;
using TORO.Shared.Routes;
using TORO.Client.Extensions;
using System.Net.Http.Json;
using TORO.Shared.Requests;

namespace TORO.Client.Managers;

public interface IUsuarioManager
{
    Task<ResultList<UsuarioRecord>> GetAsync();
    Task<Result<UsuarioRecord>> GetByIdAsync(int id);
    Task<Result<int>> CreateAsync(UsuarioCreateRequest request);
    
}

public class UsuarioManager : IUsuarioManager
{
    private readonly HttpClient httpClient;

    public UsuarioManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<UsuarioRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(UsuarioRouteManager.BASE);
            var resultado = await response.ToResultList<UsuarioRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<UsuarioRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync( UsuarioCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(UsuarioRouteManager.BASE,request);
        return await response.ToResult<int>();
    }
     public async Task<Result<UsuarioRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(UsuarioRouteManager.BuilRoute(Id));
        return await response.ToResult<UsuarioRecord>();
    }

}