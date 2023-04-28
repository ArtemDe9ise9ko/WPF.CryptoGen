using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using WPF.CryptoGen.Client.Interfaces;
using HorizontalAlignment = OxyPlot.HorizontalAlignment;
using VerticalAlignment = OxyPlot.VerticalAlignment;

namespace WPF.CryptoGen.Client.Services
{
    public class PlotService : IPlotService
    {
        private readonly Color _textColor = (Color)new ColorConverter().ConvertFromString(Application.Current.FindResource("TextColor").ToString());
        private readonly Color _lineSeriesColor = (Color)new ColorConverter().ConvertFromString(Application.Current.FindResource("LineSeriesColor").ToString());
        private readonly Color _areaSeriesColor = (Color)new ColorConverter().ConvertFromString(Application.Current.FindResource("AreaSeriesColor").ToString());
        private const double INTEND_X = 0.5;
        private const double INTEND_Y = 5;
        public PlotController GetPlotController()
        {
            return Get();
        }
        public PlotModel GetPlotModel()
        {
            return CreatePlot();
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
        private PlotModel CreatePlot()
        {
            LinearAxis axisLeft = CreateAxisLeft();
            LinearAxis axisBottomSeries = CreateAxisBottom();
            AreaSeries areaSeries = CreateArea();
            AddAreaPoints(ref areaSeries);
            DataPoint lastDataPoint = areaSeries.Points.Last();
            ScatterSeries scatterSeries = CreateScatterSeries();
            scatterSeries.Points.Add(new ScatterPoint(lastDataPoint.X, lastDataPoint.Y));
            LineAnnotation horizontalLineAnnotation = CreateHorizontalAnnotation(lastDataPoint);
            TextAnnotation annotation = CreateAnnotation(axisLeft, lastDataPoint);

            PlotModel plotModel = new PlotModel();

            plotModel.Axes.Add(axisLeft);
            plotModel.Axes.Add(axisBottomSeries);
            plotModel.Axes[0].Maximum = areaSeries.Points.Max(x => x.Y) + INTEND_Y;
            plotModel.Axes[1].Maximum = lastDataPoint.X + INTEND_X;
            plotModel.PlotAreaBorderThickness = new OxyThickness(1, 0, 0, 1);
            plotModel.PlotAreaBorderColor = OxyColor.FromRgb(_textColor.R, _textColor.G, _textColor.B);
            plotModel.Annotations.Add(horizontalLineAnnotation);
            plotModel.Annotations.Add(annotation);
            plotModel.Series.Add(areaSeries);
            plotModel.Series.Add(scatterSeries);

            return plotModel;
        }
        private void AddAreaPoints(ref AreaSeries areaSeries)
        {
            var random = new Random(1);
            var dailyOutput = 0;

            for (int i = 0; i <= 80; i++)
            {
                areaSeries.Points.Add(new DataPoint(i, dailyOutput));

                dailyOutput = Math.Max(0, dailyOutput + random.Next(-180, 223));
            }
        }
        private LinearAxis CreateAxisLeft()
        {
            return new LinearAxis
            {
                Minimum = 0,
                Position = AxisPosition.Left,
                TextColor = OxyColor.FromRgb(_textColor.R, _textColor.G, _textColor.B),
                TicklineColor = OxyColor.FromRgb(_textColor.R, _textColor.G, _textColor.B)
            };
        }
        private LinearAxis CreateAxisBottom()
        {
            return new LinearAxis
            {
                Minimum = 0,
                Position = AxisPosition.Bottom,
                TextColor = OxyColor.FromRgb(_textColor.R, _textColor.G, _textColor.B),
                TicklineColor = OxyColor.FromRgb(_textColor.R, _textColor.G, _textColor.B)
            };
        }
        private AreaSeries CreateArea()
        {
            return new AreaSeries()
            {
                Color = OxyColor.FromRgb(_lineSeriesColor.R, _lineSeriesColor.G, _lineSeriesColor.B),
                Fill = OxyColor.FromRgb(_areaSeriesColor.R, _areaSeriesColor.G, _areaSeriesColor.B),
                Color2 = OxyColors.Transparent
            };
        }
        private LineAnnotation CreateHorizontalAnnotation(DataPoint lastDataPoint)
        {
            return new LineAnnotation
            {
                Y = lastDataPoint.Y,
                X = lastDataPoint.X,
                Type = LineAnnotationType.Horizontal,
                LineStyle = LineStyle.Dot,
                StrokeThickness = 1,
                Color = OxyColor.FromRgb(_lineSeriesColor.R, _lineSeriesColor.G, _lineSeriesColor.B),
                TextHorizontalAlignment = HorizontalAlignment.Right,
                TextVerticalAlignment = VerticalAlignment.Bottom,
            };
        }
        private ScatterSeries CreateScatterSeries()
        {
            return new ScatterSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerFill = OxyColor.FromRgb(_lineSeriesColor.R, _lineSeriesColor.G, _lineSeriesColor.B),
                DataFieldX = "X",
                DataFieldY = "Y"
            };
        }
        private TextAnnotation CreateAnnotation(LinearAxis axisLeft, DataPoint lastDataPoint)
        {
            return new TextAnnotation
            {
                Text = string.Format("{0:F2}", lastDataPoint.Y),
                TextHorizontalAlignment = HorizontalAlignment.Left,
                TextVerticalAlignment = VerticalAlignment.Bottom,
                TextPosition = new DataPoint(axisLeft.ActualMinimum + INTEND_X, lastDataPoint.Y),
                Background = OxyColor.FromRgb(_areaSeriesColor.R, _areaSeriesColor.G, _areaSeriesColor.B),
                TextColor = OxyColor.FromRgb(_textColor.R, _textColor.G, _textColor.B),
                StrokeThickness = 0.3
            };
        }
    }
}
