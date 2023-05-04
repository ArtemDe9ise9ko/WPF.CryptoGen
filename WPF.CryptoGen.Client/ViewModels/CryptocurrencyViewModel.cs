using System.Threading.Tasks;
using System.Threading;
using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using WPF.CryptoGen.Client.Core;
using WPF.CryptoGen.Domain.Models;
using WPF.CryptoGen.Domain.Constants;
using WPF.CryptoGen.Infrastructure.Services.Convert;
using WPF.CryptoGen.Application.Interfaces;

namespace WPF.CryptoGen.Client.ViewModels
{
    public class CryptocurrencyViewModel : MainViewModel
    {
        public ObservableCollection<MainModel> CoinListMain { get; set;}
        public string ApiName { get;}
        private readonly IHttpService _httpService;
        private static CancellationTokenSource _tokenSource = new();

        private string _timerText;
        public string TimerText { get { return _timerText; } set { _timerText = value; OnPropertyChanged("TimerText"); }}
        double counter = TimeConstants.INTERVAL_REQUEST;

        public CryptocurrencyViewModel(IHttpService httpService, 
            ICurrentNavigation currentNavigation)  : base(currentNavigation)
        {
            _httpService = httpService;

            var _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();

            FillCoinList();

            ApiName = CryptoUrlInstance.GetInstance().GetTopCryptoName();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            counter--;

            TimerText = counter.ToString();

            if (counter == 0) counter = TimeConstants.INTERVAL_REQUEST;
        }

        private void FillCoinList()
        {
            CoinListMain = new ObservableCollection<MainModel>();
            string currentUrl = CryptoUrlInstance.GetInstance().GetTopCryptoApi();

            switch (currentUrl)
            {
                case ApiConstants.COIN_GECKO:
                    CoinGeckoFiller(currentUrl);
                    break;
                case ApiConstants.COIN_CAP:
                    CoinCapFiller(currentUrl);
                    break;
                case ApiConstants.CRYPTING_UP:
                    CryptingUpFiller(currentUrl);
                    break;
            }
        }
        private void CoinGeckoFiller(string currentUrl)
        {
            //todo Api
        }
        private void CoinCapFiller(string currentUrl)
        {
            try
            {
                Task.Run(async () =>
                {
                    await _httpService.SendAsync<AssetsRoot>(currentUrl, TimeSpan.FromSeconds(TimeConstants.INTERVAL_REQUEST), result =>
                    {
                        var models = ConvertModelService.ConvertModel(result);
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            CoinListMain.Clear();
                            foreach (var model in models)
                            {
                                CoinListMain.Add(model);
                            }
                        });

                    }, _tokenSource.Token);
                });
            }
            catch (Exception)
            {
                //Exception
            }
        }
        private void CryptingUpFiller(string currentUrl)
        {
            //todo Api
        }
    }
}
