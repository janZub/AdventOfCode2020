using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day23
{
    public class PuzzleDay24a : Puzzle
    {
        protected ulong solution;
        protected string inputFileileName = "Day24Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected List<string> instructions = new List<string>();
        protected List<Tuple<int, int>> titleLocation = new List<Tuple<int, int>>();

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            instructions = input;

        }
        public override void Solve()
        {
            foreach (var instruction in instructions)
            {
                var shiftToRight = 0;
                var shiftToBot = 0;
                var extractedInstructions = ExtractTnstructions(instruction);
                foreach (var singleInstruction in extractedInstructions)
                {

                    if (singleInstruction.Length == 2)
                    {
                        if (singleInstruction[0] == 'n')
                            shiftToBot += -1;
                        else
                            shiftToBot += 1;

                        if (singleInstruction[1] == 'e')
                            shiftToRight += -1;
                        else
                            shiftToRight += 1;
                    }
                    else
                    {
                        if (singleInstruction[0] == 'e')
                            shiftToRight += -2;
                        else
                            shiftToRight += 2;
                    }
                }
                titleLocation.Add(new Tuple<int, int>(shiftToBot, shiftToRight));
            }
            var group = titleLocation.GroupBy(
                i => i,
                i => i,
                  (keys, numbersGrouped) =>
                    new
                    {
                    total = numbersGrouped.Count()
                    });

            solution =(ulong) group.Where(i => (i.total % 2) == 1).ToList().Count();
        }
        public override void DeliverResults()
        {
        }

        private List<string> ExtractTnstructions(string instruction)
        {
            var instructions =new List<string>();

            for (int i = 0; i < instruction.Length;)
            {
                var instructionLength = 1;
                if (instruction[i] == 's' || instruction[i] == 'n')
                    instructionLength = 2;
                
                var singleinstruction = instruction.Substring(i, instructionLength);
                instructions.Add(singleinstruction);
                i += instructionLength;
            }

            return instructions;
        }
    }
}