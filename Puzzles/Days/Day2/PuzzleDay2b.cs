using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day2
{
    public class PuzzleDay2b : PuzzleDay2
    {
        protected private PuzzleDay2bSolver solver = new PuzzleDay2bSolver();
        protected List<PasswordPolicyDay2b> inputData = new List<PasswordPolicyDay2b>();

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            inputData = input.Select(s => new PasswordPolicyDay2b(s)).ToList();
        }

        public override void Solve()
        {
            solution = solver.GetNumberOfValidPasswords(inputData);
        }
    }
}