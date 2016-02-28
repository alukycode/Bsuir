using System.Diagnostics;

namespace MathModeling.Lab1
{
    /// <summary>
    /// ����������������� ������������ �����
    /// </summary>
    public class CongruentRandom : IRandomGenerator
    {
        private readonly int m;
        private readonly int k;
        private int seed;

        public string Name => "����������������� ������������ �����";

        /// <summary>
        /// ����������������� ������������ (����������) �����
        /// </summary>
        /// <param name="m">������ m ����� ����������� ���������. ��� �������� ��� ����� ����� m = 2^n.</param>
        /// <param name="k">���������� ������� ��������� k, ������� ������� � m</param>
        /// <param name="seed">��������� ��������</param>
        public CongruentRandom(int m, int k, int seed)
        {
            Debug.Assert(m > 0);

            this.m = m;
            this.k = k;
            this.seed = seed;
        }

        /// <summary>
        /// ��������� ���������� �����
        /// </summary>
        /// <returns>��������������� ����� � ��������� [0; 1)</returns>
        public double GenerateNext()
        {
            var result = this.k * this.seed % this.m;
            this.seed = result;
            return (double)result / this.m;
        }
    }
}