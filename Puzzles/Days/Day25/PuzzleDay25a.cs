using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day25
{
    public class PuzzleDay25a : Puzzle
    {
        protected ulong solution;
        protected string inputFileileName = "Day25Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected ulong cardPublicKey;
        protected ulong doorPublicKey;

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            cardPublicKey = ulong.Parse(input[0]);
            doorPublicKey = ulong.Parse(input[1]);
        }
        public override void Solve()
        {
            var doorLoopSize = FindLoopSize(cardPublicKey);
            solution = TransformNumber(doorPublicKey, doorLoopSize);

        }
        public override void DeliverResults()
        {
        }

        private ulong FindLoopSize(ulong publicKey)
        {
            ulong doorLoopSize = 0;
            ulong value = 1;

            while (true)
            {
                ++doorLoopSize;
                value *= 7;
                value %= 20201227;

                if (value == publicKey)
                    return doorLoopSize;
            }
        }
        private ulong TransformNumber(ulong value, ulong loopSize)
        {
            ulong encryption = 1;
            for (ulong i = 0; i < loopSize; i++)
            {
                encryption *= value;
                encryption %= 20201227;
            }
            return encryption;
        }
    }
}