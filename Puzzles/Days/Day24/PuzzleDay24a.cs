using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day24
{
    public class PuzzleDay24a : PuzzleDay24
    {
        public override void Solve()
        {
            solution = tiles.BlackTilesCount();
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Nr of black tiles is {0}.", solution));
        }
    }
}