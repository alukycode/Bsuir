using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathModeling.ConsoleApplication
{
    public static class ConsoleHelper
    {
        public static T Input<T>(T min, T max, T defaultValue) where T : IConvertible, IComparable
        {
            while (true)
            {
                try
                {
                    var str = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(str))
                    {
                        Console.WriteLine("* Используем значение по умолчанию: {0}", defaultValue);
                        return defaultValue;
                    }

                    var value = (T)Convert.ChangeType(str, typeof(T));
                    if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
                        throw new ArgumentOutOfRangeException();

                    return value;
                }
                catch
                {
                    Console.Write("* Некорректное значение! Ещё раз:");
                }
            }
        }
    }
}
