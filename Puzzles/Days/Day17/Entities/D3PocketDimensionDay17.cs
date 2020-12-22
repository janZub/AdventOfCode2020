using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Day17
{
    public class D3PocketDimensionDay17 : IDimension
    {
        private CubeDay17[,,] cubes;
        private int width;
        private int height;
        private int depth;

        private ICubeActivationStrategy<CubeDay17[,,]> strategy;

        public D3PocketDimensionDay17(CubeDay17[,,] pocketDimensionCubes, ICubeActivationStrategy<CubeDay17[,,]> cubeStrategy)
        {
            cubes = pocketDimensionCubes;
            height = cubes.GetLength(0);
            width = cubes.GetLength(1);
            depth = cubes.GetLength(2);

            strategy = cubeStrategy;
        }

        public int GetNumberOfActiveCubes()
        {
            var numberOfOccupiedCubes = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    for (int k = 0; k < depth; k++)
                    {
                        if (cubes[i, j, k].IsOccupied())
                        {
                            numberOfOccupiedCubes++;
                        }
                    }
                }
            }
            return numberOfOccupiedCubes;
        }
        public bool ChangeState()
        {
            var cubesToChangeState = GetCubesToChange();
            var changedStae = false;

            foreach (var cube in cubesToChangeState)
            {
                if (cube.ChangeState())
                    changedStae = true;
            }

            return changedStae;
        }

        private List<CubeDay17> GetCubesToChange()
        {
            var cubesToChange = new List<CubeDay17>();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    for (int k = 0; k < depth; k++)
                    {
                        var cube = cubes[i, j, k];
                        var points = new List<int>() { i, j, k };
                        var occupiedNeighbours = strategy.CountOccupiedNeighbours(cubes, points);

                        if (strategy.ShouldChangeState(cube, occupiedNeighbours))
                            cubesToChange.Add(cube);
                    }
                }
            }

            return cubesToChange;
        }
    }
}