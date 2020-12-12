using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles
{
    public class PuzzleDay1bSolver
    {
        /* Last step -> solver1a is O(n * log(n)) 
         * The foreach loop is n
         * Max deph is k - 2
         * So it's O(n^(k-2))
         * Total should be O(n^(k-2) * n * log(n)) 
         * => O(n^(k-1) * log(n))
         */

        /* We should inject PuzzleDay1aSolver as dependency 
         * and unit test should do it with mock.
         * Otherwise it's integration test.
         * -------------------------------------------------
         * In fact we should:
         * - move only function of PuzzleDay1a here and delete that class
         * - change name of PuzzleDay1bSolver => PuzzleDay1Solver
         * - we would have class with 2 public functions.
         * Now we have 1 public function and dependency which is worse.
         */

        private PuzzleDay1aSolver solver1a = new PuzzleDay1aSolver();
        public List<int> GetKNumbersThatSumToN(List<int> numbers, int k, int n)
        {
            if (numbers.Count < k)
                throw new ArgumentException("There are too few numbers in list", "k");

            if (k == 2)
                return SolveFor2Numbers(numbers, n);

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
        private List<int> SolveFor2Numbers(List<int> numbers, int n)
        {
            return solver1a.GetNumbersThatSumToN(numbers, n);
        }
    }
}