using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Day3
{
    public class PuzzleSolverDay3a
    {
        public int GetNumberOfTreesInAway(MapDay3a map)
        {
            var numberOfTrees = 0;

            while (!map.DidLeftMap())
            {
                if (map.IsAtTree())
                    numberOfTrees++;

                map.Move();
            }
            return numberOfTrees;
        }
    }
}