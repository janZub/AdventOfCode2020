using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day17
{
    public interface ICubeActivationStrategy<T>
    {
        public int CountOccupiedNeighbours(T cubes, List<int> points);
        public bool ShouldChangeState(CubeDay17 cube, int neighbours);
    }
}
