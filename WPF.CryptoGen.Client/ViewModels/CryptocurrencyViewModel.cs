using OxyPlot;
using WPF.CryptoGen.Client.Interfaces;
using WPF.CryptoGen.Client.Stores;

namespace WPF.CryptoGen.Client.ViewModels
{
    public class CryptocurrencyViewModel : ViewModelBase
    {
        public PlotModel PlotModel { get; }
        public PlotController PlotController { get;}
        public string ApiName { get;}

        private readonly string _currentUrl; 

        private readonly IPlotService _plotService;

        public CryptocurrencyViewModel(IPlotService plotService)
        {
            _plotService = plotService;

            _currentUrl = CryptoUrlInstance.GetInstance().GetTopCryptoApi();
            ApiName= CryptoUrlInstance.GetInstance().GetTopCryptoName();

            PlotController = _plotService.GetPlotController();
            PlotModel = _plotService.GetPlotModel();
        }
    }
}
