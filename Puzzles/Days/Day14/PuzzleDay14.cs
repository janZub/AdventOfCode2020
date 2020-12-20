using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day14
{
    public abstract class PuzzleDay14 : Puzzle
    {
        protected ulong solution;
        protected List<MemoryInputDay14> inputData = new List<MemoryInputDay14>();

        protected string inputFileileName = "Day14Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("The sum is {0}.", solution));
        }

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            var firstMask = InputHandlerServiceDay14.ExtractMask(input[0]);
            input.RemoveAt(0);

            var mask = CreateMask(firstMask);
            for (int i = 0; i < input.Count; i++)
            {
                if (InputHandlerServiceDay14.IsMask(input[i]))
                {
                    var maskCode = InputHandlerServiceDay14.ExtractMask(input[i]);
                    mask = CreateMask(maskCode);
                }
                else
                {
                    var memoryData = InputHandlerServiceDay14.CreateMemoryInput(i, input[i], mask);
                    inputData.Add(memoryData);
                }
            }
        }
        protected abstract MaskDay14 CreateMask(string maskCode);
    }
}