using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day7
{
    public class PuzzleDay7a : PuzzleDay7
    {       
        public override void Solve()
        {
            solution = solver.FindNumberConnectedNodes(inputData, "shiny gold");
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("You can bring in, shiny gold bag in {0} other colors!", solution));
        }
    }
}