using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Day13
{
    public class ChineseTheoremDay13
    {
        public static ulong ComputeProductN(List<ulong> numbers)
        {
            ulong result = 1;
            foreach (var n in numbers)
                result *= n;

            return result;
        }

        public static ulong SolveForNPrimes(List<Tuple<ulong, ulong>> numbersAndReminders)
        {
            var numbers = numbersAndReminders.Select(i => i.Item2).ToList();
            var reminders = numbersAndReminders.Select(i => i.Item1).ToList();

            ulong n = ComputeProductN(numbers);

            ulong result = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                ulong ni = numbers[i];
                ulong Ni = n / ni;
                var b = EuclidForCoPrimeDay13.GetCofficentBForNi(ni, Ni);
                result += Ni * reminders[i] * b;
            }
            result %= n;
            if (result < numbers.Max())
                return n + result;

            return result;
        }
    }
}