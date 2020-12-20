using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day14
{
    public class PuzzleDay14b : PuzzleDay14
    {
        public override void Solve()
        {
            var memory = new Dictionary<ulong, ulong>();
            foreach (var memoryData in inputData)
            {
                var unstableAddress = NumberToCharConverterDay14.ApplyMaskToNumber((ulong)memoryData.MemoryIndex, memoryData.Mask);
                var memoryToApplyNumber = NumberToCharConverterDay14.CreateNumbersFromInstableAddress(unstableAddress);
              
                foreach (var mem in memoryToApplyNumber)
                {
                    if (memory.ContainsKey(mem))
                        memory[mem] = memoryData.Number;
                    else
                        memory.Add(mem, memoryData.Number);
                }

            }
            solution = memory.Values.Aggregate((a, c) => a + c);
        }

        protected override MaskDay14 CreateMask(string maskCode)
        {
            return new MaskDay14b(maskCode);
        }
    }
}