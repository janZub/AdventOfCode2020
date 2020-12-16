using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day7
{
    public class PuzzleDay7b : PuzzleDay7
    {
       public override void Solve()
        {
            solution = solver.FindWeightInNode(inputData, "shiny gold", new HashSet<string>()) - 1;
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Shiny gold bag will contain {0} other bags!", solution));
        }
    }
}