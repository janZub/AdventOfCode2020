using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day17
{
    public class D4CloseNeighboursStrategy<T> : ICubeActivationStrategy<CubeDay17[,,,]>
    {
        public int CountOccupiedNeighbours(CubeDay17[,,,] cubes, List<int> points)
        {
            var occupiedNeighbourSeats = 0;
            var maxColumnIndex = cubes.GetLength(0) - 1;
            var maxRowIndex = cubes.GetLength(1) - 1;
            var maxDepthIndex = cubes.GetLength(2) - 1;
            var max4rthIndex = cubes.GetLength(3) - 1;

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int z = -1; z <= 1; z++)
                    {
                        for (int w = -1; w <= 1; w++)
                        {
                            var neighbourCoulmnIndex = points[0] - x;
                            var neighbourRowIndex = points[1] - y;
                            var neighbourDepthIndex = points[2] - z;
                            var neighbour4thIndex = points[3] - w;

                            if (neighbourCoulmnIndex == points[0]
                                && neighbourRowIndex == points[1]
                                && neighbourDepthIndex == points[2]
                                && neighbour4thIndex == points[3])
                                continue;

                            if (neighbourCoulmnIndex < 0 || neighbourCoulmnIndex > maxColumnIndex)
                                continue;

                            if (neighbourRowIndex < 0 || neighbourRowIndex > maxRowIndex)
                                continue;

                            if (neighbourDepthIndex < 0 || neighbourDepthIndex > maxDepthIndex)
                                continue;

                            if (neighbour4thIndex < 0 || neighbour4thIndex > max4rthIndex)
                                continue;

                            if (cubes[neighbourCoulmnIndex, neighbourRowIndex, neighbourDepthIndex, neighbour4thIndex].IsOccupied())
                            {
                                occupiedNeighbourSeats++;
                            }
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