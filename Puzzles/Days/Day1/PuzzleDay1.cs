﻿using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day1
{
    public abstract class PuzzleDay1 : Puzzle
    {
        protected private PuzzleSolverDay1 solver = new PuzzleSolverDay1();
        protected List<ulong> inputData = new List<ulong>();
        protected List<ulong> solution = new List<ulong>();

        protected string inputFileileName = "Day1Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected virtual int numberOfComponents { get; }
        protected virtual ulong sumTo { get; }

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            inputData = input.Select(i => ulong.Parse(i)).ToList();
        }
        public override void DeliverResults()
        {
            if (solution.Count != numberOfComponents)
                Console.WriteLine("Failed to find solution.");
            else
            {
                FormatFoundNumberMessage();
                FormatFoundQuotientMessage();
            }
        }

        public override void Solve()
        {
            solution = solver.GetKNumbersThatSumToN(inputData, numberOfComponents, sumTo);
        }

        private void FormatFoundNumberMessage()
        {
            var msg = string.Join(" and ", solution);
            Console.WriteLine(string.Format("Solution are numbers {0}.", msg));
        }
        private void FormatFoundQuotientMessage()
        {
            var msg = string.Join(" * ", solution);
            ulong r = 1;
            for (int i = 0; i < solution.Count; i++)
            {
                r *= solution[i];
            }

            Console.WriteLine(string.Format("{0} = {1}.", msg, r));
        }
    }
}