using OxyPlot;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System;
using WPF.CryptoGen.Client.Interfaces;
using WPF.CryptoGen.Client.Stores;
using Newtonsoft.Json;
using WPF.CryptoGen.Client.Model;
using System.Collections.Generic;
using WPF.CryptoGen.Client.Services;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows;

namespace WPF.CryptoGen.Client.ViewModels
{
    public class CryptocurrencyViewModel : ViewModelBase
    {
        public PlotModel PlotModel { get; }
        public PlotController PlotController { get;}
        public string ApiName { get;}
        public ObservableCollection<MainModel> CoinListMain { get; set;}

        private readonly IPlotService _plotService;

        private static CancellationTokenSource _tokenSource = new();
        public CryptocurrencyViewModel(IPlotService plotService)
        {
            _plotService = plotService;

            ApiName= CryptoUrlInstance.GetInstance().GetTopCryptoName();
            string currentUrl = CryptoUrlInstance.GetInstance().GetTopCryptoApi();

            CoinListMain = new ObservableCollection<MainModel>();

            try
            {
                Task.Run(async () => {
                    await SendAsync<AssetsRoot>(currentUrl, TimeSpan.FromSeconds(5), result =>
                    {
                        var models = ConvertModel(result);
                        Application.Current.Dispatcher.Invoke(() => {
                            CoinListMain.Clear();
                            foreach (var model in models)
                            {
                                CoinListMain.Add(model);
                            }
                        });

                        //var models = ConvertModel(result);
                        //if (CoinListMain.Count != 0)
                        //{
                        //    CoinListMain.Clear();
                        //}

                        //foreach (var model in models)
                        //{
                        //    Application.Current.Dispatcher.Invoke(() => CoinListMain.Add(model));
                        //}
                    }, _tokenSource.Token);
                });
            }
            catch (Exception)
            {
                //Exception
            }

            PlotController = _plotService.GetPlotController();
            PlotModel = _plotService.GetPlotModel();
        }
        private static List<MainModel> ConvertModel(AssetsRoot model)
        {
            List<MainModel> views = new List<MainModel>();
            foreach (var item in model.Data)
            {
                views.Add(new MainModel
                {
                    Path = $"https://assets.coincap.io/assets/icons/{item.Symbol.ToLower()}@2x.png",
                    Symbol = item.Symbol,
                    Name = item.Name,
                    Price = ConvertService.ConvertPrice(item.PriceUsd),
                    Change = ConvertService.ConvertChange(item.ChangePercent24Hr)
                });
            }
            return views;
        }
        private async Task<T> SendAsync<T>(string url, TimeSpan interval, Action<T> callback, CancellationToken cancellationToken)
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
