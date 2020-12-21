using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day17
{
    public class CloseNeighboursStrategy : ICubeActivationStrategy
    {
        public int CountOccupiedNeighbours(CubeDay17[,,] cubes, int i, int j, int k)
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
                        var neighbourCoulmnIndex = i - m;
                        var neighbourRowIndex = j - l;
                        var neighbourDepthIndex = k - n;

                        if (neighbourCoulmnIndex == i && neighbourRowIndex == j && neighbourDepthIndex == k)
                            continue;

                        if (neighbourCoulmnIndex < 0 || neighbourCoulmnIndex > maxColumnIndex)
                            continue;

                        if (neighbourRowIndex < 0 || neighbourRowIndex > maxRowIndex)
                            continue;

                        if (neighbourDepthIndex < 0 || neighbourDepthIndex > maxDepthIndex)
                            continue;

                        if (cubes[neighbourCoulmnIndex, neighbourRowIndex, neighbourDepthIndex].IsOccupied())
                        {
                            if (k == 0 && neighbourDepthIndex !=0)
                                occupiedNeighbourSeats++;

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