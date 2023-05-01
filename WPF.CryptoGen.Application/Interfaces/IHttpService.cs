namespace WPF.CryptoGen.Application.Interfaces
{
    public interface IHttpService
    {
        Task<T> SendAsync<T>(string url, TimeSpan interval, Action<T> callback, CancellationToken cancellationToken);
    }
}
