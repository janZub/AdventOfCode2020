using Puzzles;
using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = PuzzleFactory.GetPuzzle(6, "b");

            day.ReadInput();
            day.Solve();
            day.DeliverResults();

        }
    }
}
