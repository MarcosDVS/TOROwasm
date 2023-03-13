using TORO.Shared.Wrapper;
using Newtonsoft.Json;

namespace TORO.Client.Extensions;


internal static class ResultExtensions
{
   internal static async Task<Result<T>> ToResult<T>(this HttpResponseMessage response)
   {
      var respuesta_a_texto = await response.Content.ReadAsStringAsync();
      var objecto = JsonConvert.DeserializeObject<Result<T>>(respuesta_a_texto);

      return objecto!;
   }

   internal static async Task<ResultList<T>> ToResultList<T>(this HttpResponseMessage response)
   {
      var respuesta_a_texto = await response.Content.ReadAsStringAsync();
      var objecto = JsonConvert.DeserializeObject<ResultList<T>>(respuesta_a_texto);

      return objecto!;
   }
}