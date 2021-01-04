using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day24
{
    public interface INeighboourStrategy
    {
        public int CountOccupiedNeighbours(TileDay24[,] tiles, int i, int j);
        public bool ShouldChangeState(TileDay24 tile);
    }
}
