using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Drawing;
using System.Linq;

namespace WPF.CryptoGen.Client.ViewModels
{
    public class CryptocurrencyViewModel : ViewModelBase
    {
        public PlotModel PlotModel { get; set; }
        public PlotController PlotController { get;}

        public CryptocurrencyViewModel()
        {
            ColorConverter converter = new ColorConverter();
            Color textColor = (Color)converter.ConvertFromString(System.Windows.Application.Current.FindResource("TextColor").ToString());
            Color lineSeriesColor = (Color)converter.ConvertFromString(System.Windows.Application.Current.FindResource("LineSeriesColor").ToString());
            Color areaSeriesColor = (Color)converter.ConvertFromString(System.Windows.Application.Current.FindResource("AreaSeriesColor").ToString());

            LinearAxis axisLeft = new LinearAxis();
            axisLeft.Minimum = 0;
            axisLeft.Position = AxisPosition.Left;
            axisLeft.TextColor = OxyColor.FromRgb(textColor.R, textColor.G, textColor.B);
            axisLeft.TicklineColor = OxyColor.FromRgb(textColor.R, textColor.G, textColor.B);

            LinearAxis axisBottomSeries = new LinearAxis();
            axisBottomSeries.Minimum = 0;
            axisBottomSeries.Position = AxisPosition.Bottom;
            axisBottomSeries.TextColor = OxyColor.FromRgb(textColor.R, textColor.G, textColor.B);
            axisBottomSeries.TicklineColor = OxyColor.FromRgb(textColor.R, textColor.G, textColor.B);

            var areaSeries = new AreaSeries()
            {
                Color = OxyColor.FromRgb(lineSeriesColor.R, lineSeriesColor.G, lineSeriesColor.B),
                Fill = OxyColor.FromRgb(areaSeriesColor.R, areaSeriesColor.G, areaSeriesColor.B),
                Color2 = OxyColors.Transparent
            };

            var r = new Random(1);
            var dailyOutput = 0;

            for (int i = 0; i <= 80; i++)
            {
                areaSeries.Points.Add(new DataPoint(i, dailyOutput));

                dailyOutput = Math.Max(0, dailyOutput + r.Next(-222, 223));
            }

            var lastDataPoint = areaSeries.Points.Last();
            var maxDataPointY = areaSeries.Points.Max(x => x.Y);

            var horizontalLineAnnotation = new LineAnnotation
            {
                Y = lastDataPoint.Y,
                X = lastDataPoint.X,
                Type = LineAnnotationType.Horizontal,
                LineStyle = LineStyle.Dot,
                StrokeThickness = 1,
                Color = OxyColor.FromRgb(lineSeriesColor.R, lineSeriesColor.G, lineSeriesColor.B),
                TextHorizontalAlignment = HorizontalAlignment.Right,
                TextVerticalAlignment = VerticalAlignment.Bottom,
            };

            var scatterSeries = new ScatterSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerFill = OxyColor.FromRgb(lineSeriesColor.R, lineSeriesColor.G, lineSeriesColor.B),
                DataFieldX = "X",
                DataFieldY = "Y"
            };

            scatterSeries.Points.Add(new ScatterPoint(lastDataPoint.X, lastDataPoint.Y));

            var annotation = new TextAnnotation
            {
                Text = string.Format("{0:F2}", maxDataPointY),
                TextHorizontalAlignment = HorizontalAlignment.Left,
                TextVerticalAlignment = VerticalAlignment.Bottom,
                TextPosition = new DataPoint(axisLeft.ActualMinimum + 1.5, lastDataPoint.Y),
                Background = OxyColor.FromRgb(areaSeriesColor.R, areaSeriesColor.G, areaSeriesColor.B),
                TextColor = OxyColor.FromRgb(textColor.R, textColor.G, textColor.B),
            };

            PlotController = new PlotController();
            PlotController.UnbindMouseDown(OxyMouseButton.Left);
            PlotController.UnbindMouseDown(OxyMouseButton.Right);
            PlotController.BindMouseDown(OxyMouseButton.Left, PlotCommands.SnapTrack);
            PlotController.BindMouseDown(OxyMouseButton.Right, PlotCommands.PanAt);

            PlotModel = new PlotModel();

            PlotModel.PlotAreaBorderThickness = new OxyThickness(1,0,0,1);
            PlotModel.PlotAreaBorderColor = OxyColor.FromRgb(textColor.R, textColor.G, textColor.B);

            PlotModel.Annotations.Add(horizontalLineAnnotation);
            PlotModel.Annotations.Add(annotation);

            PlotModel.Axes.Add(axisLeft);
            PlotModel.Axes.Add(axisBottomSeries);

            ((LinearAxis)PlotModel.Axes[0]).Maximum = maxDataPointY + 5;
            ((LinearAxis)PlotModel.Axes[1]).Maximum = lastDataPoint.X + 3;

            PlotModel.Series.Add(areaSeries);
            PlotModel.Series.Add(scatterSeries);
        }
    }
}
