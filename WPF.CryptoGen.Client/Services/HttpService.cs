using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System;
using WPF.CryptoGen.Client.Interfaces;

namespace WPF.CryptoGen.Client.Services
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
