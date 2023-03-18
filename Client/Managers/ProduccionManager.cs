using TORO.Shared.Wrapper;
using TORO.Shared.Records;
using TORO.Shared.Routes;
using TORO.Client.Extensions;
using System.Net.Http.Json;
using TORO.Shared.Requests;

namespace TORO.Client.Managers;

public interface IProduccionManager
{
    Task<ResultList<ProduccionRecord>> GetAsync();
    Task<Result<ProduccionRecord>> GetByIdAsync(int id);
    Task<Result<int>> CreateAsync(ProduccionCreateRequest request);
    
}

public class ProduccionManager : IProduccionManager
{
    private readonly HttpClient httpClient;

    public ProduccionManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<ProduccionRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(ProduccionRouteManager.BASE);
            var resultado = await response.ToResultList<ProduccionRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<ProduccionRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync( ProduccionCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(ProduccionRouteManager.BASE,request);
        return await response.ToResult<int>();
    }
     public async Task<Result<ProduccionRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(ProduccionRouteManager.BuilRoute(Id));
        return await response.ToResult<ProduccionRecord>();
    }

}