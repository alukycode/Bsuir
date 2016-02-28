using System.Collections.Generic;
using MathModeling.Lab1;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace MathModeling.Wpf
{
    public class Lab1ViewModel
    {
        public Lab1ViewModel()
        {
            this.Title = "Лабораторная работа 1";
            this.Subtitle = "Датчики базовых случайных величин";

            var plotStatsList = new List<StatisticalAnalysis>
            {
                new StatisticalAnalysis(new SquareRandom(1994), 20, 5, 2),
                new StatisticalAnalysis(new SquareRandom(2016), 100, 5, 2),
                new StatisticalAnalysis(new CongruentRandom(32768, 32749, 1), 100, 5, 2),
                new StatisticalAnalysis(new CongruentRandom(65536, 32749, 1), 1000, 5, 2)
            };

            this.ChartModels = new List<PlotModel>();
            foreach (var stats in plotStatsList)
            {
                stats.CalculateValues();

                var model = new PlotModel();
                model.Subtitle = stats.Generator.Name;

                var columnSeries = new ColumnSeries();
                var categoryAxis = new CategoryAxis();
                categoryAxis.GapWidth = 0;
                foreach (var intervalData in stats.Intervals)
                {
                    columnSeries.Items.Add(new ColumnItem(intervalData.RelativeFrequency));
                    categoryAxis.Labels.Add(intervalData.LowerBound.ToString("N2") + "-" + intervalData.UpperBound.ToString("N2"));
                }
                columnSeries.LabelFormatString = "{0}";
                columnSeries.LabelPlacement = LabelPlacement.Base;
                model.Series.Add(columnSeries);
                model.Axes.Add(categoryAxis);

                this.ChartModels.Add(model);
            }

            this.Stats = plotStatsList;
        }

        public IList<PlotModel> ChartModels { get; private set; }

        public IList<StatisticalAnalysis> Stats { get; private set; }

        public string Title { get; private set; }

        public string Subtitle { get; private set; }

    }
}
