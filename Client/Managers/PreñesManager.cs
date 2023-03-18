using TORO.Shared.Wrapper;
using TORO.Shared.Records;
using TORO.Shared.Routes;
using TORO.Client.Extensions;
using System.Net.Http.Json;
using TORO.Shared.Requests;

namespace TORO.Client.Managers;

public interface IPreñesManager
{
    Task<ResultList<preñesRecord>> GetAsync();
    Task<Result<preñesRecord>> GetByIdAsync(int id);
    Task<Result<int>> CreateAsync(PreñesCreateRequest request);
    
}

public class PreñesManager : IPreñesManager
{
    private readonly HttpClient httpClient;

    public PreñesManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<preñesRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(PreñesRouteManager.BASE);
            var resultado = await response.ToResultList<preñesRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<preñesRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync( PreñesCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(PreñesRouteManager.BASE,request);
        return await response.ToResult<int>();
    }
     public async Task<Result<preñesRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(PreñesRouteManager.BuilRoute(Id));
        return await response.ToResult<preñesRecord>();
    }

}