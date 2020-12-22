using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day17
{
    public class D3CloseNeighboursStrategy<T> : ICubeActivationStrategy<CubeDay17[,,]>
    {
        public int CountOccupiedNeighbours(CubeDay17[,,] cubes, List<int> points)
        {
            var occupiedNeighbourSeats = 0;
            var maxColumnIndex = cubes.GetLength(0) - 1;
            var maxRowIndex = cubes.GetLength(1) - 1;
            var maxDepthIndex = cubes.GetLength(2) - 1;

            for (int m = -1; m <= 1; m++)
            {
                for (int l = -1; l <= 1; l++)
                {
                    for (int n = -1; n <= 1; n++)
                    {
                        var neighbourCoulmnIndex = points[0] - m;
                        var neighbourRowIndex = points[1] - l;
                        var neighbourDepthIndex = points[2] - n;

                        if (neighbourCoulmnIndex == points[0] && neighbourRowIndex == points[1] && neighbourDepthIndex == points[2])
                            continue;

                        if (neighbourCoulmnIndex < 0 || neighbourCoulmnIndex > maxColumnIndex)
                            continue;

                        if (neighbourRowIndex < 0 || neighbourRowIndex > maxRowIndex)
                            continue;

                        if (neighbourDepthIndex < 0 || neighbourDepthIndex > maxDepthIndex)
                            continue;

                        if (cubes[neighbourCoulmnIndex, neighbourRowIndex, neighbourDepthIndex].IsOccupied())
                        {
                            occupiedNeighbourSeats++;
                        }
                    }
                }
            }

            return occupiedNeighbourSeats;
        }

        public bool ShouldChangeState(CubeDay17 cube, int neighbours)
        {
            if (cube.IsOccupied())
                return !(neighbours == 2 || neighbours == 3);
            else
                return neighbours == 3;
        }
    }
}