using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day14
{
    public class PuzzleDay14a : PuzzleDay14
    {
        public override void Solve()
        {
            var maxMemory = inputData.Select(w => w.MemoryIndex).Max();
            var memory = new ulong[maxMemory + 1];
            foreach (var memeoryData in inputData)
            {
                var numberAfterMask = NumberToCharConverterDay14.ApplyMaskToNumber(memeoryData.Number, memeoryData.Mask);
                memory[memeoryData.MemoryIndex] = NumberToCharConverterDay14.ConvertCharArrayToNumber(numberAfterMask);
            }
            solution = memory.Aggregate((a, c) => a + c);
        }

        protected override MaskDay14 CreateMask(string maskCode)
        {
            return new MaskDay14a(maskCode);
        }
    }
}