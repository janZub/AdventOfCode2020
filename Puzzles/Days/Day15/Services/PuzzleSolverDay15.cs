using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Day15
{
    public class PuzzleSolverDay15
    {
        public ulong SolveMemoryGame(List<int> inputData, ulong numberOfSpokenWord)
        {
            var dict = new Dictionary<ulong, ulong>();

            for (int i = 0; i < inputData.Count - 1; i++)
                dict.Add((ulong)inputData[i], (ulong)i + 1);

            ulong spokenNumbers = (ulong)dict.Count + 1;
            ulong lastSpoken = (ulong)inputData.Last();
            ulong spokenOnTurn = 0;

            while (spokenNumbers <= numberOfSpokenWord)
            {
                if (dict.TryGetValue(lastSpoken, out spokenOnTurn))
                {
                    dict[lastSpoken] = spokenNumbers;
                    lastSpoken = spokenNumbers - spokenOnTurn;
                }
                else
                {
                    dict.Add(lastSpoken, spokenNumbers);
                    lastSpoken = 0;
                }
                spokenNumbers++;
            }
            var max = dict.First(e => e.Value == numberOfSpokenWord).Key;

            return max;
        }
    }
}
