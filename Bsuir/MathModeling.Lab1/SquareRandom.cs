namespace MathModeling.Lab1
{
    /// <summary>
    /// ����� �������� ��������
    /// </summary>
    public class SquareRandom : IRandomGenerator
    {
        private int seed;

        private const int MaxValue = 10000;

        public string Name => "����� �������� ��������";

        /// <summary>
        /// ����� �������� ��������
        /// </summary>
        /// <param name="seed">������������ 4-������� �����</param>
        public SquareRandom(int seed)
        {
            this.seed = seed;
        }

        /// <summary>
        /// ��������� ���������� �����
        /// </summary>
        /// <returns>��������������� ����� � ��������� [0; 1)</returns>
        public double GenerateNext()
        {
            var square = this.seed * this.seed;
            var result = square / 100 % MaxValue;

            this.seed = result;

            return (double)result / MaxValue;
        }
    }
}