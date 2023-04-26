using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WPF.CryptoGen.Client.ViewModels
{
    public class CryptocurrencyViewModel : ViewModelBase
    {
        public PlotModel PlotModel { get; set; }

        public CryptocurrencyViewModel()
        {
            // Create the plot model and add the X and Y axes
            PlotModel = new PlotModel();

            PlotModel.PlotAreaBorderThickness = new OxyThickness(1,0,0,1);
            PlotModel.PlotAreaBorderColor = OxyColors.Purple;

            LinearAxis axisLeftSeries = new LinearAxis();
            axisLeftSeries.Position = AxisPosition.Left;
            axisLeftSeries.TextColor = OxyColors.Black;
            axisLeftSeries.TicklineColor = OxyColors.Purple;
            axisLeftSeries.TitleColor = OxyColors.Purple;

            PlotModel.Axes.Add(axisLeftSeries);

            LinearAxis axisBottomSeries = new LinearAxis();
            axisBottomSeries.Position = AxisPosition.Bottom;
            axisBottomSeries.TextColor = OxyColors.Black;
            axisBottomSeries.TicklineColor = OxyColors.Purple;
            axisBottomSeries.TitleColor = OxyColors.Purple;

            PlotModel.Axes.Add(axisBottomSeries);

            LineSeries lineSeries = new LineSeries();
            lineSeries.Color = OxyColor.FromAColor(200, OxyColors.Green);
            lineSeries.Points.Add(new DataPoint(0, 0));
            lineSeries.Points.Add(new DataPoint(1, 1));
            lineSeries.Points.Add(new DataPoint(2, 0.5));
            lineSeries.Points.Add(new DataPoint(3, 1.5));
            lineSeries.Points.Add(new DataPoint(4, 2.5));

            PlotModel.Series.Add(lineSeries);
        }
    }
}
