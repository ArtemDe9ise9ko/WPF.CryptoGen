using Newtonsoft.Json;
using WPF.CryptoGen.Application.Interfaces;

namespace WPF.CryptoGen.Infrastructure.Services.Http
{
    public class HttpService : IHttpService
    {
        public async Task<T> SendAsync<T>(string url, TimeSpan interval, Action<T> callback, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        var responce = await client.GetAsync(url);
                        responce.EnsureSuccessStatusCode();
                        var content = await responce.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<T>(content);
                        callback(result);
                    }
                    catch (Exception)
                    {
                        // handle exception//
                    }
                }
                await Task.Delay(interval);
            }
            return default(T);
        }
    }
}
