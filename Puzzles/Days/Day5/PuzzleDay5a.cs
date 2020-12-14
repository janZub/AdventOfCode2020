using System;

namespace Puzzles.Day5
{
    public class PuzzleDay5a : PuzzleDay5
    {
        public override void Solve()
        {
            solution = solver.GetMaxSeatId(inputData);
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Biggest seat id is: {0}.", solution));
        }
    }
}