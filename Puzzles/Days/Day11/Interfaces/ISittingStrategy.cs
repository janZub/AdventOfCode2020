using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day11
{
    public interface ISittingStrategy
    {
        public int CountOccupiedNeighbours(SeatDay11[,] seats, int i, int j);
        public bool ShouldChangeState(SeatDay11 seat, int neighbours);
    }
}
