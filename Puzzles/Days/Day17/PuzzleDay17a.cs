using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day17
{
    public class PuzzleDay17a : Puzzle
    {
        protected PocketDimensionDay17 inputData;
        protected int solution;
        protected int cycles = 6;

        protected string inputFileileName = "Day17Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("There are {0} seats occupied.", solution));

        }
        public override void ReadInput()
        {
            var cubes = ProcessInputToArray(cycles + 1);
            inputData = new PocketDimensionDay17(cubes, new CloseNeighboursStrategy());
        }
        public override void Solve()
        {
            for (int i = 0; i < cycles; i++)
            {
                inputData.ChangeState();
            }
            solution = inputData.GetNumberOfActiveCubes();
        }
        protected CubeDay17[,,] ProcessInputToArray(int maxDepth)
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);
            var width = input[0].Trim().Length;
            var height = input.Count;

            var maxWidth = width + 2 * maxDepth;
            var maxHeight = height + 2 * maxDepth;

            var cubes = new CubeDay17[maxHeight, maxWidth, maxDepth];

            for (int i = 0; i < maxHeight; i++)
                for (int j = 0; j < maxWidth; j++)
                    for (int k = 0; k < maxDepth; k++)
                    {
                        if (k == 0
                            && i > maxDepth -1 && j > maxDepth- 1
                            && i < height +  maxDepth
                            && j < width + maxDepth)
                            
                            cubes[i, j, k] = new CubeDay17(input[i-maxDepth].Trim()[j -maxDepth]);
                        else
                            cubes[i, j, k] = new CubeDay17('.');
                    }
            return cubes;
        }
    }
}