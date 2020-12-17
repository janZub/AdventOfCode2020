using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Day10
{
    public class PuzzleSolverDay10
    {
        public int GetProductOfJoltDifferences(List<int> joltRatings)
        {
            var joltDifferenceOf1 = 0;
            var joltDifferenceOf3 = 0;

            var joltRatingsSortedList = new List<int>(joltRatings.OrderBy(r => r));

            joltRatingsSortedList.Insert(0,0);
            joltRatingsSortedList.Add(joltRatingsSortedList.Last() + 3);

            for (int i = 0; i < joltRatingsSortedList.Count - 1; i++)
            {
                var difference = joltRatingsSortedList[i + 1] - joltRatingsSortedList[i];

                if (difference == 1)
                    joltDifferenceOf1++;

                if (difference == 3)
                    joltDifferenceOf3++;
            }

            return joltDifferenceOf1 * joltDifferenceOf3;
        }
    }
}