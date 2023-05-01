using OxyPlot;
using System.Threading.Tasks;
using System.Threading;
using System;
using WPF.CryptoGen.Client.Interfaces;
using WPF.CryptoGen.Client.Model;
using WPF.CryptoGen.Client.Services;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using WPF.CryptoGen.Client.Core;

namespace WPF.CryptoGen.Client.ViewModels
{
    public class CryptocurrencyViewModel : MainViewModel
    {
        public PlotModel PlotModel { get; }
        public PlotController PlotController { get;}
        public ObservableCollection<MainModel> CoinListMain { get; set;}
        public string ApiName { get;}
        private readonly IPlotService _plotService;
        private readonly IHttpService _httpService;
        private static CancellationTokenSource _tokenSource = new();

        private string _timerText;
        public string TimerText { get { return _timerText; } set { _timerText = value; OnPropertyChanged("TimerText"); }}
        double counter = Constants.INTERVAL_REQUEST;

        public CryptocurrencyViewModel(IPlotService plotService, IHttpService httpService, 
            ICurrentNavigation currentNavigation)  : base(currentNavigation)
        {
            _plotService = plotService;
            _httpService = httpService;

            var _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();

            FillCoinList();

            ApiName = CryptoUrlInstance.GetInstance().GetTopCryptoName();

            PlotController = _plotService.GetPlotController();
            PlotModel = _plotService.GetPlotModel();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            counter--;

            TimerText = counter.ToString();

            if(counter == 0) counter = Constants.INTERVAL_REQUEST;
        }

        private void FillCoinList()
        {
            CoinListMain = new ObservableCollection<MainModel>();
            string currentUrl = CryptoUrlInstance.GetInstance().GetTopCryptoApi();

            switch (currentUrl)
            {
                case Constants.COIN_GECKO:
                    CoinGeckoFiller(currentUrl);
                    break;
                case Constants.COIN_CAP:
                    CoinCapFiller(currentUrl);
                    break;
                case Constants.CRYPTING_UP:
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
                    await _httpService.SendAsync<AssetsRoot>(currentUrl, TimeSpan.FromSeconds(Constants.INTERVAL_REQUEST), result =>
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
