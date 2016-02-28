using System.Diagnostics;

namespace MathModeling.Lab1
{
    /// <summary>
    /// Мультипликативный конгруэнтный метод
    /// </summary>
    public class CongruentRandom : IRandomGenerator
    {
        private readonly int m;
        private readonly int k;
        private int seed;

        public string Name => "Мультипликативный конгруэнтный метод";

        /// <summary>
        /// Мультипликативный конгруэнтный (остатковый) метод
        /// </summary>
        /// <param name="m">Модуль m берут максимально возможным. Для двоичных ЭВМ часто берут m = 2^n.</param>
        /// <param name="k">Достаточно большой множитель k, взаимно простой с m</param>
        /// <param name="seed">Начальное значение</param>
        public CongruentRandom(int m, int k, int seed)
        {
            Debug.Assert(m > 0);

            this.m = m;
            this.k = k;
            this.seed = seed;
        }

        /// <summary>
        /// Генерация случайного числа
        /// </summary>
        /// <returns>Сгенерированное число в интервале [0; 1)</returns>
        public double GenerateNext()
        {
            var result = this.k * this.seed % this.m;
            this.seed = result;
            return (double)result / this.m;
        }
    }
}