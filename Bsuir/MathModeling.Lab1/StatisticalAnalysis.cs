using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MathModeling.Lab1
{
    /// <summary>
    /// Проверка равномерности распределения с помощью частотного теста
    /// и проверка статистической независимости с помощью оценки корреляций
    /// </summary>
    public class StatisticalAnalysis
    {
        private readonly int k;
        private readonly int s;

        public IRandomGenerator Generator { get; }

        public double[] GeneratedValues { get; }

        public double IntervalSize { get; private set; }

        public IntervalData[] Intervals { get; }

        public int N { get; private set; }

        public double M { get; private set; }

        public double D { get; private set; }

        public double R { get; private set; }

        /// <summary>
        /// Проверка равномерности распределения с помощью частотного теста
        /// и проверка статистической независимости с помощью оценки корреляций
        /// </summary>
        /// <param name="generator">Генератор случайных значений</param>
        /// <param name="n">Количество генерируемых чисел</param>
        /// <param name="k">Количество отрезков на интервале [0; 1)</param>
        /// <param name="s">Шаг между сгенерированными числами для оценки корреляции</param>
        public StatisticalAnalysis(IRandomGenerator generator, int n, int k, int s)
        {
            this.Generator = generator;
            this.N = n;
            this.k = k;
            this.s = s;

            this.Intervals = new IntervalData[k];
            for (var i = 0; i < k; i++)
            {
                this.Intervals[i] = new IntervalData();
            }

            this.GeneratedValues = new double[n];
        }

        /// <summary>
        /// Расчёт оценок для проверки
        /// </summary>
        public void CalculateValues()
        {
            this.IntervalSize = 1.0 / this.k;

            for (var i = 0; i < this.N; i++)
            {
                var generatedValue = Generator.GenerateNext();
                this.GeneratedValues[i] = generatedValue;
            }

            for (var i = 0; i < this.k; i++)
            {
                this.Intervals[i].LowerBound = this.IntervalSize * i;
                this.Intervals[i].UpperBound = this.IntervalSize * (i + 1);
            }

            foreach (var generatedValue in this.GeneratedValues)
            {
                var intervalNumber = (int)(generatedValue / this.IntervalSize);

                Debug.Assert(generatedValue < 1);
                Debug.Assert(intervalNumber < this.k);

                this.Intervals[intervalNumber].Count++;
            }

            foreach (var intervalData in this.Intervals)
            {
                intervalData.RelativeFrequency = (double)intervalData.Count / this.N;
            }

            this.M = this.GeneratedValues.Sum() / this.N;
            this.D = this.GeneratedValues.Select(x => x * x).Sum() / this.N - this.M * this.M;

            double aggregatedValues = 0;
            for (var i = 0; i < this.N - this.s; i++)
            {
                aggregatedValues += this.GeneratedValues[i] * this.GeneratedValues[i + s];
            }

            this.R = 12.0 / (this.N - this.s) * aggregatedValues - 3;
        }
    }
}