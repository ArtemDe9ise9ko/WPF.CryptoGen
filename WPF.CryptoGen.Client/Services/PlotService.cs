using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using WPF.CryptoGen.Client.Interfaces;
using static System.Resources.ResXFileRef;
using HorizontalAlignment = OxyPlot.HorizontalAlignment;
using VerticalAlignment = OxyPlot.VerticalAlignment;

namespace WPF.CryptoGen.Client.Services
{
    public class PlotService : IPlotService
    {
        private readonly Color _textColor = (Color)new ColorConverter().ConvertFromString(Application.Current.FindResource("TextColor").ToString());
        private readonly Color _lineSeriesColor = (Color)new ColorConverter().ConvertFromString(Application.Current.FindResource("LineSeriesColor").ToString());
        private readonly Color _areaSeriesColor = (Color)new ColorConverter().ConvertFromString(Application.Current.FindResource("AreaSeriesColor").ToString());
        public PlotController GetPlotController()
        {
            return Get();
        }
        public PlotModel GetPlotModel()
        {
            return GetPlot();
        }

        private static PlotController Get()
        {
            PlotController plotController = new PlotController();

            plotController.UnbindMouseDown(OxyMouseButton.Left);
            plotController.UnbindMouseDown(OxyMouseButton.Right);
            plotController.BindMouseDown(OxyMouseButton.Left, PlotCommands.SnapTrack);
            plotController.BindMouseDown(OxyMouseButton.Right, PlotCommands.PanAt);

            return plotController;
        }
        private static PlotModel GetPlot()
        {
            ColorConverter converter = new ColorConverter();
            Color textColor = (Color)converter.ConvertFromString(Application.Current.FindResource("TextColor").ToString());
            Color lineSeriesColor = (Color)converter.ConvertFromString(Application.Current.FindResource("LineSeriesColor").ToString());
            Color areaSeriesColor = (Color)converter.ConvertFromString(Application.Current.FindResource("AreaSeriesColor").ToString());

            LinearAxis axisLeft = CreateAxisLeft(textColor);

            LinearAxis axisBottomSeries = CreateAxisBottom(textColor);

            AreaSeries areaSeries = CreateArea(lineSeriesColor, areaSeriesColor);

            var lastDataPoint = areaSeries.Points.Last();
            var maxDataPointY = areaSeries.Points.Max(x => x.Y);

            LineAnnotation horizontalLineAnnotation = CreateHorizontalAnnotation(lineSeriesColor, ref lastDataPoint);

            ScatterSeries scatterSeries = CreateScatterSeries(lineSeriesColor);

            scatterSeries.Points.Add(new ScatterPoint(lastDataPoint.X, lastDataPoint.Y));

            TextAnnotation annotation = CreateAnnotation(textColor, areaSeriesColor, axisLeft, ref lastDataPoint);

            PlotModel plotModel = new PlotModel();
            plotModel.PlotAreaBorderThickness = new OxyThickness(1, 0, 0, 1);
            plotModel.PlotAreaBorderColor = OxyColor.FromRgb(textColor.R, textColor.G, textColor.B);
            plotModel.Annotations.Add(horizontalLineAnnotation);
            plotModel.Annotations.Add(annotation);
            plotModel.Axes.Add(axisLeft);
            plotModel.Axes.Add(axisBottomSeries);
            plotModel.Axes[0].Maximum = maxDataPointY + 5;
            plotModel.Axes[1].Maximum = lastDataPoint.X + 3;
            plotModel.Series.Add(areaSeries);
            plotModel.Series.Add(scatterSeries);

            return plotModel;
        }

        private static LinearAxis CreateAxisLeft(Color textColor)
        {
            LinearAxis axisLeft = new LinearAxis();
            axisLeft.Minimum = 0;
            axisLeft.Position = AxisPosition.Left;
            axisLeft.TextColor = OxyColor.FromRgb(textColor.R, textColor.G, textColor.B);
            axisLeft.TicklineColor = OxyColor.FromRgb(textColor.R, textColor.G, textColor.B);
            return axisLeft;
        }

        private static LinearAxis CreateAxisBottom(Color textColor)
        {
            LinearAxis axisBottomSeries = new LinearAxis();
            axisBottomSeries.Minimum = 0;
            axisBottomSeries.Position = AxisPosition.Bottom;
            axisBottomSeries.TextColor = OxyColor.FromRgb(textColor.R, textColor.G, textColor.B);
            axisBottomSeries.TicklineColor = OxyColor.FromRgb(textColor.R, textColor.G, textColor.B);
            return axisBottomSeries;
        }

        private static AreaSeries CreateArea(Color lineSeriesColor, Color areaSeriesColor)
        {
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

                dailyOutput = Math.Max(0, dailyOutput + r.Next(-180, 223));
            }

            return areaSeries;
        }

        private static LineAnnotation CreateHorizontalAnnotation(Color lineSeriesColor, ref DataPoint lastDataPoint)
        {
            return new LineAnnotation
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
        }

        private static ScatterSeries CreateScatterSeries(Color lineSeriesColor)
        {
            return new ScatterSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerFill = OxyColor.FromRgb(lineSeriesColor.R, lineSeriesColor.G, lineSeriesColor.B),
                DataFieldX = "X",
                DataFieldY = "Y"
            };
        }

        private static TextAnnotation CreateAnnotation(Color textColor, Color areaSeriesColor, LinearAxis axisLeft, ref DataPoint lastDataPoint)
        {
            var annotation = new TextAnnotation();
            annotation.Text = string.Format("{0:F2}", lastDataPoint.Y);
            annotation.TextHorizontalAlignment = HorizontalAlignment.Left;
            annotation.TextVerticalAlignment = VerticalAlignment.Bottom;
            annotation.TextPosition = new DataPoint(axisLeft.ActualMinimum + 1.5, lastDataPoint.Y);
            annotation.Background = OxyColor.FromRgb(areaSeriesColor.R, areaSeriesColor.G, areaSeriesColor.B);
            annotation.TextColor = OxyColor.FromRgb(textColor.R, textColor.G, textColor.B);

            return annotation;
        }
    }
}
