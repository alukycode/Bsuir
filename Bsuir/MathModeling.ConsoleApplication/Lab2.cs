using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

// ReSharper disable InconsistentNaming

namespace MathModeling.ConsoleApplication
{
    public static class Lab2
    {
        public static int N = 100000; // количество генерируемых чисел

        public static void ImitationSimple()
        {
            Console.WriteLine("Имитация случайного события.");

            Console.Write("Вероятность появления события А (0 <= Pa <= 1) = ");
            var Pa = Convert.ToDouble(Console.ReadLine());

            Debug.Assert(Pa >= 0 && Pa <= 1);

            Console.WriteLine("-----------------------------------");

            var random = new Random();
            var randomNumbers = new List<double>();
            for (int i = 0; i < N; i++)
            {
                randomNumbers.Add(random.NextDouble());
            }

            var positiveCount = randomNumbers.Count(x => x < Pa);

            Console.WriteLine("Событие А произошло {0} раз(a).", positiveCount);
            Console.WriteLine("Событие А не произошло {0} раз(a).", N - positiveCount);
            Console.WriteLine();

            // Mx = sum(xi) / N;  = 0.5
            // Dx = 1 / (n - 1) * sum((xi - Mx).^ 2); = 1/12
        }

        public static void ImitationComplexIndependent()
        {
            Console.WriteLine("Имитация сложного события.");

            Console.Write("Вероятность появления события А = ");
            var Pa = Convert.ToDouble(Console.ReadLine());
            Console.Write("Вероятность появления события B = ");
            var Pb = Convert.ToDouble(Console.ReadLine());

            Debug.Assert(Pa >= 0 && Pa <= 1);
            Debug.Assert(Pb >= 0 && Pb <= 1);

            Console.WriteLine("-----------------------------------");

            var random = new Random();
            var randomNumbers = new List<Tuple<double, double>>();
            for (var i = 0; i < N; i++)
            {
                var x1 = random.NextDouble();
                var x2 = random.NextDouble();
                var x = new Tuple<double, double>(x1, x2);
                randomNumbers.Add(x);
            }

            var posAposB = randomNumbers.Count(x => x.Item1 <= Pa & x.Item2 <= Pb);
            var posAnegB = randomNumbers.Count(x => x.Item1 <= Pa & x.Item2 > Pb);
            var negAposB = randomNumbers.Count(x => x.Item1 > Pa & x.Item2 <= Pb);
            var negAnegB = randomNumbers.Count(x => x.Item1 > Pa & x.Item2 > Pb);

            Console.WriteLine("Событие А произошло одновременно с событием B {0} раз(a).", posAposB);
            Console.WriteLine("Событие А произошло, когда событие В не произошло {0} раз(а).", posAnegB);
            Console.WriteLine("Событие А не произошло, когда событие В произошло {0} раз(а).", negAposB);
            Console.WriteLine("Событие А не произошло, когда событие В не произошло {0} раз(а).", negAnegB);
            Console.WriteLine();
        }

        public static void ImitationDependent()
        {
            Console.WriteLine("Имитация сложного события, состоящего из зависимых событий.");

            Console.Write("Вероятность появления события А = ");
            var Pa = Convert.ToDouble(Console.ReadLine());
            Console.Write("Вероятность появления события B = ");
            var Pb = Convert.ToDouble(Console.ReadLine());
            Console.Write("Условная вероятность появления события В, когда событие А произошло = ");
            var PposAposB = Convert.ToDouble(Console.ReadLine());

            Debug.Assert(Pa >= 0 && Pa <= 1);
            Debug.Assert(Pb >= 0 && Pb <= 1);
            Debug.Assert(PposAposB >= 0 && PposAposB <= 1);

            // Pb = PposAposB * Pa + PnegAposB * (1 - Pa)
            // => Pb - PposAposB * Pa = PnegAposB * (1 - Pa)
            // => (Pb - PposAposB * Pa) / (1 - Pa) = PnegAposB
            var PnegAposB = (Pb - PposAposB * Pa) / (1 - Pa);
            Console.WriteLine("Условная вероятность появления события В, когда событие А не произошло = {0}", PnegAposB.ToString("N2"));

            Console.WriteLine("-----------------------------------");

            var random = new Random();
            var randomNumbers = new List<Tuple<double, double>>();
            for (var i = 0; i < N; i++)
            {
                var x1 = random.NextDouble();
                var x2 = random.NextDouble();
                var x = new Tuple<double, double>(x1, x2);
                randomNumbers.Add(x);
            }

            var posAposB = randomNumbers.Count(x => x.Item1 <= Pa & x.Item2 <= PposAposB);
            var posAnegB = randomNumbers.Count(x => x.Item1 <= Pa & x.Item2 > PposAposB);
            var negAposB = randomNumbers.Count(x => x.Item1 > Pa & x.Item2 <= PnegAposB);
            var negAnegB = randomNumbers.Count(x => x.Item1 > Pa & x.Item2 > PnegAposB);

            Console.WriteLine("Событие А произошло, событие В произошло: {0} раз(a).", posAposB);
            Console.WriteLine("Событие А произошло, событие В не произошло: {0} раз(а).", posAnegB);
            Console.WriteLine("Событие А не произошло, событие В произошло: {0} раз(а).", negAposB);
            Console.WriteLine("Событие А не произошло, событие В не произошло: {0} раз(а).", negAnegB);
            Console.WriteLine();

            // Mxa = (pa_pb + pa_qb) / N;
            // Mxb = (pa_pb + qa_pb) / N;
            // Dx = 1 / (n - 1) * sum((xi - Mx).^ 2);
            // Console.Write("Оценка мат. ожидания случайной велечины Xa: %.4f\n", Mxa);
            // Console.Write("Оценка мат. ожидания случайной велечины Xb: %.4f\n", Mxb);
        }

        public static void ImitationFullGroup()
        {
            Console.WriteLine("Имитация событий, составлющих полную группу.");

            Console.Write("Число событий = ");
            var eventsCount = Convert.ToInt32(Console.ReadLine());

            var eventsProbability = new double[eventsCount];
            for (var i = 0; i < eventsCount - 1; i++)
            {
                Console.Write("Вероятность появления {0} события = ", i + 1);
                eventsProbability[i] = Convert.ToDouble(Console.ReadLine());
            }
            var lastEventProbability = 1 - eventsProbability.Sum();
            eventsProbability[eventsCount - 1] = lastEventProbability;
            Console.WriteLine("Вероятность появления {0} события = {1}", eventsCount, lastEventProbability);

            Debug.Assert(lastEventProbability >= 0 && lastEventProbability <= 1);

            Console.WriteLine("-----------------------------------");

            var random = new Random();
            var randomNumbers = new List<double>();
            for (var i = 0; i < N; i++)
            {
                randomNumbers.Add(random.NextDouble());
            }

            for (int i = 0; i < eventsCount; i++)
            {
                double lowerBound = 0;
                for (var j = 0; j < i; j++)
                    lowerBound += eventsProbability[j];
                var upperBound = lowerBound + eventsProbability[i];

                var count = randomNumbers.Count(x => x >= lowerBound & x < upperBound);
                Console.WriteLine("Событие {0} произошло: {1} раз(a).", i, count);
            }

            Console.WriteLine();
        }

        public static void PiratesGame()
        {
            Console.Write("Количество игр: ");
            var gamesCount = ConsoleHelper.Input(1, int.MaxValue, 1000);

            Console.Write("Стоимость одной игры: ");
            var gamePrice = ConsoleHelper.Input(1, int.MaxValue, 1);

            Console.Write("Целевой выигрыш: ");
            var targetProfit = ConsoleHelper.Input(1, 100000, 100);

            Console.Write("Предполагаемая вероятность выпадения подпиленной грани: ");
            var estimatedProbability = ConsoleHelper.Input(0.0, 1.0, 0.5);

            var diceFacesCount = 6; ////Console.Write("Сколько граней на кубике: ");
            var peopleCount = diceFacesCount; ////Console.Write("Сколько человек играют");

            Console.WriteLine("Предполагается, что на кубике 6 граней и играют 6 человек");

            var maxGameProfit = gamePrice * peopleCount - gamePrice;
            var totalAvailableProfit = maxGameProfit * gamesCount;
            var calculatedGameProfit = (double)targetProfit / totalAvailableProfit;

            // calculatedGameProfit = maxGameProfit * calculatedProbability - gamePrice * (1 - calculatedProbability)
            // calculatedGameProfit = maxGameProfit * calculatedProbability - gamePrice * 1 - gamePrice * calculatedProbability
            // calculatedGameProfit + gamePrice = maxGameProfit * calculatedProbability - gamePrice * calculatedProbability
            // calculatedGameProfit + gamePrice = (maxGameProfit - gamePrice) * calculatedProbability
            // (calculatedGameProfit + gamePrice) / (maxGameProfit - gamePrice) = calculatedProbability

            var calculatedProbability = (calculatedGameProfit + gamePrice) / (maxGameProfit - gamePrice);

            var random = new Random();
            var currentMoney = 0;
            for (var i = 0; i < gamesCount; i++)
            {
                var diceResult = random.NextDouble();
                if (diceResult < estimatedProbability)
                {
                    currentMoney += maxGameProfit;
                }
                else
                {
                    currentMoney -= gamePrice;
                }
            }

            Console.WriteLine("--------------");
            Console.WriteLine("Максимально возможный выигрыш за {0} игр: {1}", gamesCount, totalAvailableProfit);
            Console.WriteLine("При вероятности выпадения грани {1} выигрыш составил {2}", gamesCount, estimatedProbability, currentMoney);
            Console.WriteLine("Если планируется выиграть {1} денег, вероятность выпадения должна быть {2}", gamesCount, targetProfit, calculatedProbability);
        }
    }
}
