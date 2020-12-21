using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day18
{
    public class PuzzleDay18a : Puzzle
    {
        protected ulong solution;
        protected List<string> inputData = new List<string>();

        private string patternParanthesses = @"\(([\d\s\*\+]+)\)";
        private string patternOperations = @"([\d]+)\s?([\*+]?)\s?";
        protected string inputFileileName = "Day18Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("The sum is {0}.", solution));

        }
        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            inputData = input;
        }
        public override void Solve()
        {
            foreach (var input in inputData)
            {
                solution += SolveEquation(input);
            }
        }

        private ulong SolveEquation(string input)
        {
            while (true)
            {
                var x = Regex.Matches(input, patternParanthesses);
                if (x.Count > 0)
                {
                    for (int i = 0; i < x[0].Captures.Count; i++)
                    {
                        var subset = x[0].Captures[i];
                        var reducedSubset = SolveSubset(subset.Value);

                        var aStringBuilder = new StringBuilder(input);
                        aStringBuilder.Remove(subset.Index, subset.Length);
                        aStringBuilder.Insert(subset.Index, reducedSubset);
                        input = aStringBuilder.ToString();
                    }
                    continue;
                }

                input = SolveSubset(input);

                break;
            }
            return ulong.Parse(input);
        }
        private string SolveSubset(string equation)
        {
            var elements = Regex.Matches(equation, patternOperations);

            var result = ulong.Parse(elements[0].Groups[1].Value);
            for (int i = 1; i < elements.Count; i++)
            {
                var nextElement = ulong.Parse(elements[i].Groups[1].Value.Trim());

                if (elements[i - 1].Groups[2].Value.Trim() == "+")
                    result += nextElement;
                else
                    result *= nextElement;
            }
            return result.ToString();
        }
    }
}