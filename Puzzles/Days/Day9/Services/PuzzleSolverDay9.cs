using Puzzles.Day1;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day9
{
    public class PuzzleSolverDay9
    {
        public ulong FindNumberThatIsNotSumOfKPreviousNumbers(IPuzzleSolverDay1 helpingSolver, List<ulong> numbers,int k)
        {
            var summmingNumbers = numbers.Take(k).ToList();
            
            foreach (var number in numbers.Skip(k))
            {
                var result = helpingSolver.GetNumbersThatSumToN(summmingNumbers, number);
                if (result.Count == 0)
                    return number;

                summmingNumbers.RemoveAt(0);
                summmingNumbers.Add(number);
            }

            throw new Exception("All numbers are good.");
        }
    }
}