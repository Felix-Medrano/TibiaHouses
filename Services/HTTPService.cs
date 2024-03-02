using Newtonsoft.Json;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services
{
  public class HTTPService
  {
    private HttpClient httpClient;
    public HTTPService() { httpClient = new HttpClient(); }

    public async Task<T> Get<T>(string url) where T : class
    {
      T info = null;
      string responseJson = string.Empty;

      try
      {
        HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
        responseMessage.EnsureSuccessStatusCode();
        responseJson = await responseMessage.Content.ReadAsStringAsync();

        info = JsonConvert.DeserializeObject<T>(responseJson);

        return info;

      }
      catch (Exception)
      {
        //throw;
        //Dentro de la lista imprime ayuda visul
        return null;
      }
    }
  }
}
