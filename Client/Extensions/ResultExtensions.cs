using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net;
using TORO.Shared.Wrapper;
using Newtonsoft.Json;



namespace TORO.Client.Extensions;


internal class ResultExtensions
{
    internal static async Task<Result<T>> ToResult<T> (this HttpResponseMenssage response)
    {
      var respuesta_a_texto = response.Content.ReadAsStringAsync();
      var objeto = JsonConvert.DeserializeObjetc<Result<T>>(respuesta_a_texto);
      return objetol;
    }

    internal static async Task<ResultList<T>> ToResultList<T> (this HttpResponseMenssage response)
    {
      var respuesta_a_texto = response.Content.ReadAsStringAsync();
      var objeto = JsonConvert.DeserializeObjetc<ResultList<T>>(respuesta_a_texto);
      return objetol;
    }
}