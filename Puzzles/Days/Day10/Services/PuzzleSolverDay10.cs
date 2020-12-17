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

        /*On assumption that there is no 2 jolt dirrefence between adapters.
         * Otherwise there would be few changes for Fn=Fn-1+Fn-2+Fn-3
         */
        public ulong GetNumberOfPossibleCombinations(List<int> joltRatings)
        {
            var joltRatingsSortedList = new List<int>(joltRatings.OrderBy(r => r));
            var series = new Dictionary<int, ulong>();
            joltRatingsSortedList.Insert(0, 0);
            joltRatingsSortedList.Add(joltRatingsSortedList.Last() + 3);

            var collection = GetSubsets(joltRatingsSortedList);
            ulong combinations = 1;
            foreach (var element in collection.Where(e => e.Count > 2))
            {
                var subsetLength = element.Count;

                if(subsetLength > series.Count)
                    series = GenerateSeriesToN(series, subsetLength);

                combinations *= series[subsetLength - 1];
            }
            return combinations;
        }

        private Dictionary<int, ulong> GenerateSeriesToN(Dictionary<int, ulong> series, int n)
        {
            var seriesLength = series.Count;
            if (seriesLength < 3)
            {
                series[0] = 1;
                series[1] = 1;
                series[2] = 2;
            }
            seriesLength = series.Count;

            for (int i = seriesLength; i <= n; i++)
            {
                var nextValue = series[i - 1] + series[i - 2] + series[i - 3];
                series.Add(i, nextValue);
            }
            return series;
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
    }
}