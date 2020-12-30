using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day23
{
    public abstract class PuzzleDay23 : Puzzle
    {
        protected string inputFileileName = "Day23Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected CoralGameDay23 game = new CoralGameDay23();
        protected abstract int iterations { get; }
        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            var nrList = CreateListOfNumbers(input);
            
            game.NumbersWithConnections = CreateCoralCollectionFromList(nrList);
            game.TargetNumber = nrList[0];
        }
        public override void Solve()
        {
            for (int i = 0; i < iterations; i++)
            {
                game.PutElementsUp();
                game.RestoreLinksForCollection();
                game.SetDestination();
                game.PutDownElements();
                game.SetNewTarget();
            }
        }

        protected abstract List<int> CreateListOfNumbers(List<string> input);
        protected List<int> CreateListOfNumbersFromInput(List<string> input)
        {
            var nrList = new List<int>();
            for (int i = 0; i < input[0].Length; i++)
                nrList.Add(int.Parse(input[0][i].ToString()));

            return nrList;
        }
        private Dictionary<int,Tuple<int,int>> CreateCoralCollectionFromList(List<int> nrList)
        {
            var dict = new Dictionary<int, Tuple<int, int>>();
            for (int i = 0; i < nrList.Count; i++)
            {
                var previous = nrList[(nrList.Count() + i - 1) % nrList.Count()];
                var next = nrList[(nrList.Count() + i + 1) % nrList.Count()];

                dict.Add(nrList[i], new Tuple<int, int>(previous, next));
            }

            return dict;
        }
    }
}