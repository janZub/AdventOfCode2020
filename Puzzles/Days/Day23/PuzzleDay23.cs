using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day23
{
    public class PuzzleDay23a : Puzzle
    {
        protected ulong solution;
        protected string inputFileileName = "Day23Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        private Dictionary<int, Tuple<int, int>> numbers =new Dictionary<int, Tuple<int, int>>();
        private int firstNumber;

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            var nrList = new List<int>();

            for (int i = 0; i < input[0].Length; i++)
            {
                nrList.Add(int.Parse(input[0][i].ToString()));
            }
            nrList.AddRange(Enumerable.Range(10, 1000000 - 9));

            for (int i = 0; i < nrList.Count; i++)
            {
                var previous = nrList[(nrList.Count() + i - 1) % nrList.Count()];
                var next = nrList[(nrList.Count() + i + 1) % nrList.Count()];

                numbers.Add(nrList[i], new Tuple<int, int>(previous, next));
            }

            firstNumber = nrList[0];
        }
        public override void Solve()
        {
            var targetNumber = firstNumber;

            for (int i = 0; i < 10000000; i++)
            {
                var targetLinks = numbers[targetNumber];

                var inAir1 = RemoveNextItem(numbers[targetNumber].Item2);
                var inAir2 = RemoveNextItem(inAir1.Item2.Item2);
                var inAir3 = RemoveNextItem(inAir2.Item2.Item2);

                targetLinks = new Tuple<int, int>(targetLinks.Item1, inAir3.Item2.Item2);
                numbers[targetNumber] = targetLinks;

                var destination = FindDestination(targetNumber);
                var destinationLinks = numbers[destination];

                if (destinationLinks.Item1 == inAir3.Item1)
                    destinationLinks = new Tuple<int, int>(inAir1.Item2.Item1, destinationLinks.Item2);


                inAir1 =new Tuple<int, Tuple<int, int>>(inAir1.Item1, new Tuple<int, int>(destinationLinks.Item1, inAir1.Item2.Item2));
                inAir3 =new Tuple<int, Tuple<int, int>>(inAir3.Item1, new Tuple<int, int>(inAir3.Item2.Item1, destinationLinks.Item2));


                destinationLinks = new Tuple<int, int>(destinationLinks.Item1, inAir1.Item1);

                numbers[destination] = destinationLinks;
                AddItem(inAir1);
                AddItem(inAir2);
                AddItem(inAir3);

                targetNumber = targetLinks.Item2;

            }

            var n1Links = numbers[1];
            var nAfter1Links = numbers[n1Links.Item2];
            var nAfter2Links = numbers[nAfter1Links.Item2];
         
            solution = (ulong)n1Links.Item2 * (ulong)nAfter1Links.Item2;
        }
        public override void DeliverResults()
        {
        }

        private int FindDestination(int targetNumber)
        {
            while (true)
            {
                --targetNumber;

                if (targetNumber < 0)
                    return numbers.Max(k => k.Key);

                if (numbers.ContainsKey(targetNumber))
                    return targetNumber;
            }
        }

        private void AddItem(Tuple<int, Tuple<int, int>> fromAir)
        {
            numbers.Add(fromAir.Item1, fromAir.Item2);
        }

        private Tuple<int,Tuple<int,int>> RemoveNextItem(int targetValue)
        {
            var result = new Tuple<int, Tuple<int, int>>(targetValue, numbers[targetValue]);
            numbers.Remove(targetValue);

            return result;
        }

    }
}