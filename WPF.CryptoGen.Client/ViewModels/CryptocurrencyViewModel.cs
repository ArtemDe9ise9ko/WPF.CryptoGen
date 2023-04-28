using OxyPlot;
using WPF.CryptoGen.Client.Interfaces;

namespace WPF.CryptoGen.Client.ViewModels
{
    public class CryptocurrencyViewModel : ViewModelBase
    {
        public PlotModel PlotModel { get; }
        public PlotController PlotController { get;}

        private readonly IPlotService _plotService;

        public CryptocurrencyViewModel(IPlotService plotService)
        {
            _plotService = plotService;


            PlotController = _plotService.GetPlotController();
            PlotModel = _plotService.GetPlotModel();
        }
    }
}
