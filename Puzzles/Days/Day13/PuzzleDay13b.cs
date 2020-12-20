using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day13
{
    public class PuzzleDay13b : PuzzleDay13
    {
        protected List<string> inputData = new List<string>();
        protected ulong departureTime;

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            foreach (var bus in input[1].Split(','))
                inputData.Add(bus);
        }
        public override void Solve()
        {
            var list = new List<Tuple<ulong, ulong>>();
            for (int i = 0; i < inputData.Count; i++)
            {
                if (ulong.TryParse(inputData[i], out ulong busId))
                {
                    var reminder = (busId - ((ulong)i % busId)) % busId;
                    list.Add(new Tuple<ulong, ulong>(reminder, busId));
                }
            }
            solution = ChineseTheoremDay13.SolveForNPrimes(list);
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Searched number is: {0}.", solution));
        }
    }
}