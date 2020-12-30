using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day23
{
    public class PuzzleDay23b : PuzzleDay23
    {
        protected override int iterations => 10000000;
        public override void DeliverResults()
        {
            var n1Links = game.NumbersWithConnections[1];
            var nAfter1Links = game.NumbersWithConnections[n1Links.Item2];

            var result = (ulong)n1Links.Item2 * (ulong)nAfter1Links.Item2;

            Console.WriteLine("The product of 2 next numbers to 1 is {0}", result);
        }

        protected override List<int> CreateListOfNumbers(List<string> input)
        {
            var nrList = CreateListOfNumbersFromInput(input); 
            nrList.AddRange(Enumerable.Range(10, 1000000 - 9));

            return nrList;
        }
    }
}