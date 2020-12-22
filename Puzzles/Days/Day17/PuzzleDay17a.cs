using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day17
{
    public class PuzzleDay17a : PuzzleDay17
    {
        public override void ReadInput()
        {
            var cubes = ProcessInputToArray(cycles + 1);
            inputData = new D3PocketDimensionDay17(cubes, new D3CloseNeighboursStrategy<CubeDay17[,,]>());
        }
        public override void Solve()
        {
            for (int i = 0; i < cycles; i++)
            {
                inputData.ChangeState();
            }
            solution = inputData.GetNumberOfActiveCubes();
        }
        protected CubeDay17[,,] ProcessInputToArray(int depth)
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);
            var width = input[0].Trim().Length;
            var height = input.Count;

            var maxWidth = width + 2 * depth;
            var maxHeight = height + 2 * depth;
            var maxDepth = 1 + 2 * depth;

            var cubes = new CubeDay17[maxHeight, maxWidth, maxDepth];

            for (int i = 0; i < maxHeight; i++)
                for (int j = 0; j < maxWidth; j++)
                    for (int k = 0; k < maxDepth; k++)
                    {
                        if (k == depth + 1
                            && i > depth - 1 && j > depth - 1
                            && i < height + depth
                            && j < width + depth)

                            cubes[i, j, k] = new CubeDay17(input[i - depth].Trim()[j - depth]);
                        else
                            cubes[i, j, k] = new CubeDay17('.');
                    }
            return cubes;
        }
    }
}