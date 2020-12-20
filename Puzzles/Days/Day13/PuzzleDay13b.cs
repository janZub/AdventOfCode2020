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

        //public override void Solve()
        //{
        //    var list = new List<Tuple<ulong, ulong>>();
        //    for (int i = 0; i < inputData.Count; i++)
        //    {
        //        if (ulong.TryParse(inputData[i], out ulong busId))
        //            list.Add(new Tuple<ulong, ulong>((busId - ((ulong)i % busId)) % busId, busId));
        //    }

        //    list = list.OrderBy(t => t.Item2).ToList();
        //    var biggestItem = list.Last();

        //    var starting = 100000000000000 / biggestItem.Item2;
        //    ulong searchedTime = starting * biggestItem.Item2 + biggestItem.Item1;
        //    bool search = true;
        //    //ulong nextK = 1;
        //    while (search)
        //    {
        //        search = false;
        //        //nextK = GetNextKForPair(firstItem.Item2,biggestItem.Item2, nextK, biggestItem.Item1);
        //        searchedTime += biggestItem.Item2;

        //        foreach (var bus in list)
        //        {
        //            var mod = searchedTime % bus.Item2;
        //            if (mod != bus.Item1)
        //            {
        //                search = true;
        //                break;
        //            }
        //        }
        //    }
        //    solution = searchedTime;
        //}
        //private ulong GetNextKForPair(ulong k1, ulong k2, ulong previousK, ulong rest)
        //{
        //    var mod = k2 % k1;

        //    while (true)
        //    {
        //        ++previousK;
        //        if ((previousK * mod) % k1 == rest % k1)
        //            return previousK;
        //    }
        //}
    }
}