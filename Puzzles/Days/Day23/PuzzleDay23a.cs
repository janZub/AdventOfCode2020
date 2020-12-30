using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day23
{
    public class PuzzleDay23a : PuzzleDay23
    {
        protected override int iterations => 100;

        public override void DeliverResults()
        {
            var result = "";
            var next = 1;
            for (int i = 1; i < game.NumbersWithConnections.Count; i++)
            {
                next = game.NumbersWithConnections[next].Item2;
                result += next;
            }

            Console.WriteLine("Labels after 1 are : {0}", result);
        }

        protected override List<int> CreateListOfNumbers(List<string> input)
        {
            return CreateListOfNumbersFromInput(input);
        }
    }
}