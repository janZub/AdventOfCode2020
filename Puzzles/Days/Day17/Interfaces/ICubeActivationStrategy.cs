using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day17
{
    public interface ICubeActivationStrategy
    {
        public int CountOccupiedNeighbours(CubeDay17[,,] cubes, int i, int j, int k);
        public bool ShouldChangeState(CubeDay17 cube, int neighbours);
    }
}
