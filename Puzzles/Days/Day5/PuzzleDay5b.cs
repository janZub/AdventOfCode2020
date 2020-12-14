using System;

namespace Puzzles.Day5
{
    public class PuzzleDay5b : PuzzleDay5
    {
        public override void Solve()
        {

            solution = solver.GetMissingId(inputData);
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Your seat is: {0}.", solution));
        }
    }
}