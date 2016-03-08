using System;
using System.Globalization;
using System.Threading;

// ReSharper disable InconsistentNaming

namespace MathModeling.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            culture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = culture;

            Lab2.ImitationSimple();
            Lab2.ImitationComplexIndependent();
            Lab2.ImitationDependent();
            Lab2.ImitationFullGroup();

            Console.ReadLine();
        }
    }
}
