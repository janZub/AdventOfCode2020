using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day24
{
    public class PuzzleDay24b : PuzzleDay24
    {
        protected int nrOfCycles = 100;
        public override void Solve()
        {
            for (int i = 0; i < nrOfCycles; i++)
                tiles.ChangeState();

            solution = tiles.BlackTilesCount();
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Nr of black tiles after {0} iterations is {1}.", nrOfCycles, solution));
        }
    }
}