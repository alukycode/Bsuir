namespace MathModeling.Lab1
{
    /// <summary>
    /// Метод середины квадрата
    /// </summary>
    public class SquareRandom : IRandomGenerator
    {
        private int seed;

        private const int MaxValue = 10000;

        public string Name => "Метод середины квадрата";

        /// <summary>
        /// Метод середины квадрата
        /// </summary>
        /// <param name="seed">Произвольное 4-значное число</param>
        public SquareRandom(int seed)
        {
            this.seed = seed;
        }

        /// <summary>
        /// Генерация случайного числа
        /// </summary>
        /// <returns>Сгенерированное число в интервале [0; 1)</returns>
        public double GenerateNext()
        {
            var square = this.seed * this.seed;
            var result = square / 100 % MaxValue;

            this.seed = result;

            return (double)result / MaxValue;
        }
    }
}