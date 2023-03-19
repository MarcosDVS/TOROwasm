using TORO.Shared.Wrapper;
using TORO.Shared.Records;
using TORO.Shared.Routes;
using TORO.Client.Extensions;
using System.Net.Http.Json;
using TORO.Shared.Requests;

namespace TORO.Client.Managers;

public interface IPadreManager
{
    Task<ResultList<PadreRecord>> GetAsync();
    Task<Result<PadreRecord>> GetByIdAsync(int id);
    Task<Result<int>> CreateAsync(PadreCreateRequest request);
    
}

public class PadreManager : IPadreManager
{
    private readonly HttpClient httpClient;

    public PadreManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<PadreRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(PadreRouteManager.BASE);
            var resultado = await response.ToResultList<PadreRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<PadreRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync( PadreCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(PadreRouteManager.BASE,request);
        return await response.ToResult<int>();
    }
     public async Task<Result<PadreRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(PadreRouteManager.BuilRoute(Id));
        return await response.ToResult<PadreRecord>();
    }

}