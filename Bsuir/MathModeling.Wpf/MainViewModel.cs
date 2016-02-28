namespace MathModeling.Wpf
{
    using System;
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;

    public class MainViewModel
    {
        public MainViewModel()
        {
            var model = new PlotModel();
            model.Title = "Example 1";

            var columnSeries = new ColumnSeries();
            columnSeries.Items.Add(new ColumnItem(250));
            columnSeries.Items.Add(new ColumnItem(251));
            columnSeries.LabelFormatString = "{0}";
            columnSeries.LabelPlacement = LabelPlacement.Middle;
            model.Series.Add(columnSeries);

            var categoryAxis = new CategoryAxis();
            categoryAxis.Labels.Add("Category A");
            categoryAxis.Labels.Add("Category B");
            model.Axes.Add(categoryAxis);

            this.MyModel = model;
        }

        public PlotModel MyModel { get; private set; }
    }
}
