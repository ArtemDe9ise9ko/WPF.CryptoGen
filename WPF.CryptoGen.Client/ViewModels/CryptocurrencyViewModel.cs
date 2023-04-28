using OxyPlot;
using WPF.CryptoGen.Client.Interfaces;

namespace WPF.CryptoGen.Client.ViewModels
{
    public class CryptocurrencyViewModel : ViewModelBase
    {
        public PlotModel PlotModel { get; set; }
        public PlotController PlotController { get; set; }

        private readonly IPlotService _plotService;

        public CryptocurrencyViewModel(IPlotService plotService)
        {
            _plotService = plotService;


            PlotController = _plotService.GetPlotController();
            PlotModel = _plotService.GetPlotModel();
        }
    }
}
