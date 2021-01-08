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
        protected Cipher cipher = new Cipher();


        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            cardPublicKey = ulong.Parse(input[0]);
            doorPublicKey = ulong.Parse(input[1]);
        }
        public override void Solve()
        {
            var doorLoopSize = cipher.FindLoopSize(cardPublicKey);
            solution = cipher.TransformNumber(doorPublicKey, doorLoopSize);

        }
        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("The code is {0}", solution));
        }
    }
}