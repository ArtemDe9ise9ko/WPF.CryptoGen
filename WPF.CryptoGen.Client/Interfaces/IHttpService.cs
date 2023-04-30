using System.Threading.Tasks;
using System.Threading;
using System;

namespace WPF.CryptoGen.Client.Interfaces
{
    public interface IHttpService
    {
        Task<T> SendAsync<T>(string url, TimeSpan interval, Action<T> callback, CancellationToken cancellationToken);
    }
}
