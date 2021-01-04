using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day24
{
    public interface IInstructionService
    {
        List<string> ExtractInstructions(string instruction);
        Tuple<int, int> ComputeShift(List<string> instructions);
    }
}
