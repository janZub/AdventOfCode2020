using System;
using System.Collections.Generic;

namespace Puzzles.Day1
{
    public interface IPuzzleSolverDay1
    {
        public List<ulong> GetNumbersThatSumToN(List<ulong> list, ulong n);
    }
}