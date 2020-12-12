﻿using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day2
{
    public class PuzzleDay2a : PuzzleDay2
    {
        protected private PuzzleDay2aSolver solver = new PuzzleDay2aSolver();
        protected List<PasswordPolicyDay2a> inputData = new List<PasswordPolicyDay2a>();

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            inputData = input.Select(s => new PasswordPolicyDay2a(s)).ToList();
        }

        public override void Solve()
        {
            solution = solver.GetNumberOfValidPasswords(inputData);
        }
    }
}