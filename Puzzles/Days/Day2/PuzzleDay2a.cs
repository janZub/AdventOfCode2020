using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day2
{
    public class PuzzleDay2a : Puzzle
    {
        protected private PuzzleDay2aSolver solver = new PuzzleDay2aSolver();
        protected List<PasswordPolicy> inputData = new List<PasswordPolicy>();
        protected int solution = 0;

        protected string inputFileileName = "Day2aInput";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            inputData = input.Select(s => new PasswordPolicy(s)).ToList();
        }
        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("The number of valid password is: {0}.", solution));
        }

        public override void Solve()
        {
            solution = solver.GetNumberOfValidPasswords(inputData);
        }
    }
}