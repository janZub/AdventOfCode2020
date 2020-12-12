using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Day1
{
    public class PuzzleSolverDay1
    {
        /* Last step -> solver1a is O(n * log(n)) 
         * The foreach loop is n
         * Max deph is k - 2
         * So it's O(n^(k-2))
         * Total should be O(n^(k-2) * n * log(n)) 
         * => O(n^(k-1) * log(n))
         */
        public List<int> GetKNumbersThatSumToN(List<int> numbers, int k, int n)
        {
            if (numbers.Count < k)
                throw new ArgumentException("There are too few numbers in list", "k");

            if (k == 2)
                return GetNumbersThatSumToN(numbers, n);

            foreach (int number in numbers)
            {
                var relativeN = n - number;
                if (relativeN > 0)
                {
                    var newNumbers = new List<int>(numbers);
                    newNumbers.Remove(number);
                    var result = GetKNumbersThatSumToN(newNumbers, k - 1, relativeN);
                    if (result.Count > 0)
                        return result.Append(number).ToList();
                }
            }

            return new List<int>();
        }
        /* 
         * Sorting is O(n * log(n))
         * Comparing should be O(n), 
         * with each iteration removes last number
         * or progress to the next one
         * 
         * Total should be O(n * log(n))
         */
        public List<int> GetNumbersThatSumToN(List<int> list, int n)
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
                        (sum == n) return new List<int>() { list[i], list[k] };
                    else
                        break;

                }
            }
            return new List<int>();
        }

    }
}