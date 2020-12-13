using Puzzles;
using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = PuzzleFactory.GetPuzzle(4, "a");

            day.ReadInput();
            day.Solve();
            day.DeliverResults();

        }
    }
}
