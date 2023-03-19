using TORO.Shared.Wrapper;
using TORO.Shared.Records;
using TORO.Shared.Routes;
using TORO.Client.Extensions;
using System.Net.Http.Json;
using TORO.Shared.Requests;

namespace TORO.Client.Managers;

public interface IBovinoManager
{
    Task<ResultList<BovinoRecord>> GetAsync();
    Task<Result<BovinoRecord>> GetByIdAsync(int id);
    Task<Result<int>> CreateAsync(BovinoCreateRequest request);
    
}

public class BovinoManager : IBovinoManager
{
    private readonly HttpClient httpClient;

    public BovinoManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<BovinoRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(BovinoRouteManager.BASE);
            var resultado = await response.ToResultList<BovinoRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<BovinoRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync( BovinoCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(BovinoRouteManager.BASE,request);
        return await response.ToResult<int>();
    }
     public async Task<Result<BovinoRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(BovinoRouteManager.BuilRoute(Id));
        return await response.ToResult<BovinoRecord>();
    }

}