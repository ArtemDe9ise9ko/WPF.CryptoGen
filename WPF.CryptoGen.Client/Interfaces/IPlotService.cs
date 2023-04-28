using OxyPlot;

namespace WPF.CryptoGen.Client.Interfaces
{
    public interface IPlotService
    {
        PlotController GetPlotController();
        PlotModel GetPlotModel();
    }
}
