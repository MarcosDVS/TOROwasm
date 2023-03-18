using TORO.Shared.Wrapper;
using TORO.Shared.Records;
using TORO.Shared.Routes;
using TORO.Client.Extensions;
using System.Net.Http.Json;
using TORO.Shared.Requests;

namespace TORO.Client.Managers;

public interface IMadreManager
{
    Task<ResultList<MadreRecord>> GetAsync();
    Task<Result<MadreRecord>> GetByIdAsync(int id);
    Task<Result<int>> CreateAsync(MadreCreateRequest request);
    
}

public class MadreManager : IMadreManager
{
    private readonly HttpClient httpClient;

    public MadreManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<MadreRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(MadreRouteManager.BASE);
            var resultado = await response.ToResultList<MadreRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<MadreRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync( MadreCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(MadreRouteManager.BASE,request);
        return await response.ToResult<int>();
    }
     public async Task<Result<MadreRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(MadreRouteManager.BuilRoute(Id));
        return await response.ToResult<MadreRecord>();
    }

}