using OxyPlot;
using WPF.CryptoGen.Client.Builders;
using WPF.CryptoGen.Client.Core;

namespace WPF.CryptoGen.Client.ViewModels
{
    public class DetailViewModel : MainViewModel
    {
        public PlotModel PlotModel { get; }
        public PlotController PlotController { get;}

        private readonly IChartBuilderPlot _plotService;
        public DetailViewModel(IChartBuilderPlot plotService, ICurrentNavigation currentNavigation)  : base(currentNavigation)
        {
            _plotService = plotService;

            PlotController = _plotService.GetPlotController();
            PlotModel = _plotService.GetPlotModel();
        }
    }
}
