using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles
{
    public class PuzzleDay1aSolver
    {
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