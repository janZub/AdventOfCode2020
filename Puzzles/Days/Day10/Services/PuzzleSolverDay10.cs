using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Day10
{
    public class PuzzleSolverDay10
    {
        public ulong GetProductOfJoltDifferences(List<int> joltRatings)
        {
            ulong joltDifferenceOf1 = 0;
            ulong joltDifferenceOf3 = 0;

            var joltRatingsSortedList = new List<int>(joltRatings.OrderBy(r => r));

            joltRatingsSortedList.Insert(0, 0);
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

        /*On assumption that there is a lot 3 jolts differences,
         * and ther is no 2 jolt dirrefence between adapters.
         * Otherwise there would be few alternatives for Fn=Fn-1+Fn-2+Fn-3
         */
        public ulong GetNumberOfPossibleCombinations(List<int> joltRatings)
        {
            var joltRatingsSortedList = new List<int>(joltRatings.OrderBy(r => r));

            joltRatingsSortedList.Insert(0, 0);
            joltRatingsSortedList.Add(joltRatingsSortedList.Last() + 3);

            var collection = GetSubsets(joltRatingsSortedList);
            ulong combinations = 1;
            foreach (var element in collection.Where(e => e.Count > 2))
            {
                combinations *= GetCombinationsInSet(element);
            }
            return combinations;
        }

        private List<List<int>> GetSubsets(List<int> joltRatingsSortedList)
        {

            var collection = new List<List<int>>();
            var subset = new List<int>();
            for (int i = 0; i < joltRatingsSortedList.Count - 1; i++)
            {
                subset.Add(joltRatingsSortedList[i]);

                var difference = joltRatingsSortedList[i + 1] - joltRatingsSortedList[i];
                if (difference == 3)
                {
                    collection.Add(subset);
                    subset = new List<int>();
                }
            }
            return collection;
        }

        private ulong GetCombinationsInSet(List<int> set)
        {
            ulong combinations = 0;

            if (set.Count == 1 || set.Count == 2)
                return 1;

            combinations += GetCombinationsInSet(set.Skip(1).ToList());
            combinations += GetCombinationsInSet(set.Skip(2).ToList());

            if (set.Count > 3)
                combinations += GetCombinationsInSet(set.Skip(3).ToList());

            return combinations;
        }
    }
}