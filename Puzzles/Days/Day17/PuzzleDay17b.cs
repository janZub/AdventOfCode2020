using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day17
{
    public class PuzzleDay17b : PuzzleDay17
    {
        public override void ReadInput()
        {
            var cubes = ProcessInputToArray(cycles + 1);
            inputData = new D4PocketDimensionDay17(cubes, new D4CloseNeighboursStrategy<CubeDay17[,,,]>());
        }
        public override void Solve()
        {
            for (int i = 0; i < cycles; i++)
            {
                inputData.ChangeState();
            }
            solution = inputData.GetNumberOfActiveCubes();
        }
        protected CubeDay17[,,,] ProcessInputToArray(int depth)
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);
            var width = input[0].Trim().Length;
            var height = input.Count;

            var maxWidth = width + 2 * depth;
            var maxHeight = height + 2 * depth;
            var maxDepth = 1 + 2 * depth;
            var max4th = 1 + 2 * depth;

            var cubes = new CubeDay17[maxHeight, maxWidth, maxDepth, max4th];

            for (int x = 0; x < maxHeight; x++)
                for (int y = 0; y < maxWidth; y++)
                    for (int z = 0; z < maxDepth; z++)
                        for (int w = 0; w < max4th; w++)
                        {
                            if (z == depth + 1 && w == depth + 1
                                && x > depth - 1 && y > depth - 1
                                && x < height + depth
                                && y < width + depth)

                                cubes[x, y, z, w] = new CubeDay17(input[x - depth].Trim()[y - depth]);
                            else
                                cubes[x, y, z, w] = new CubeDay17('.');
                        }
                    
            return cubes;
        }
    }
}