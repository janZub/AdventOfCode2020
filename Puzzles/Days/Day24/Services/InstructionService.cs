using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day24
{
    public class InstructionService : IInstructionService
    {
        public List<string> ExtractInstructions(string instruction)
        {
            var instructions = new List<string>();

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
        public Tuple<int, int> ComputeShift(List<string> instructions)
        {
            var shiftToRight = 0;
            var shiftToBot = 0;
            foreach (var instruction in instructions)
            {

                if (instruction.Length == 2)
                {
                    if (instruction[0] == 'n')
                        shiftToBot += -1;
                    else
                        shiftToBot += 1;

                    if (instruction[1] == 'e')
                        shiftToRight += -1;
                    else
                        shiftToRight += 1;
                }
                else
                {
                    if (instruction[0] == 'e')
                        shiftToRight += -2;
                    else
                        shiftToRight += 2;
                }
            }

            return new Tuple<int, int>(shiftToBot, shiftToRight);
        }
    }
}