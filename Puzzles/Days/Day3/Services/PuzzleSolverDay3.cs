using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Day3
{
    public class PuzzleSolverDay3
    {
        public int GetNumberOfTreesInAway(MapDay3 map)
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

        public long GetNumberOfTreesInAway(List<MapDay3> maps)
        {
            long numberOfTrees = 1;
            foreach (var map in maps)
                numberOfTrees = numberOfTrees * GetNumberOfTreesInAway(map);

            return numberOfTrees;
        }
    }
}