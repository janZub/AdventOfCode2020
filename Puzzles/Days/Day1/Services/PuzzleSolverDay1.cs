using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Day1
{
    public class PuzzleSolverDay1 : IPuzzleSolverDay1
    {
        /* Last step -> solver1a is O(n * log(n)) 
         * The foreach loop is n
         * Max deph is k - 2
         * So it's O(n^(k-2))
         * Total should be O(n^(k-2) * n * log(n)) 
         * => O(n^(k-1) * log(n))
         */
        public List<ulong> GetKNumbersThatSumToN(List<ulong> numbers, int k, ulong n)
        {
            if (numbers.Count < k)
                throw new ArgumentException("There are too few numbers in list", "k");

            if (k == 2)
                return GetNumbersThatSumToN(numbers, n);

            foreach (var number in numbers)
            {
                if (n > number)
                {
                    var relativeN = n - number;
                    var newNumbers = new List<ulong>(numbers);
                    newNumbers.Remove(number);
                    var result = GetKNumbersThatSumToN(newNumbers, k - 1, relativeN);
                    if (result.Count > 0)
                        return result.Append(number).ToList();
                }
            }

            return new List<ulong>();
        }
        /* 
         * Sorting is O(n * log(n))
         * Comparing should be O(n), 
         * with each iteration removes last number
         * or progress to the next one
         * 
         * Total should be O(n * log(n))
         */
        public List<ulong> GetNumbersThatSumToN(List<ulong> list, ulong n)
        {
            list = list.OrderBy(i => i).ToList();

            int k = list.Count - 1;
            for (int i = 0; i <= k; i++)
            {
                while (i < k)
                {
                    var sum = list[i] + list[k];

                    if (sum > n)
                        --k;
                    else if
                        (sum == n) return new List<ulong>() { list[i], list[k] };
                    else
                        break;

                }
            }
            return new List<ulong>();
        }

    }
}