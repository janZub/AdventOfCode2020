using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day23
{
    public class PuzzleDay24a : Puzzle
    {
        protected ulong solution;
        protected string inputFileileName = "Day24Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected List<string> instructions = new List<string>();
        protected List<Tuple<int, int>> titleLocation = new List<Tuple<int, int>>();

        protected bool[,] hex = new bool[300, 600];

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            instructions = input;

        }
        public override void Solve()
        {
            foreach (var instruction in instructions)
            {
                var shiftToRight = 0;
                var shiftToBot = 0;
                var extractedInstructions = ExtractTnstructions(instruction);
                foreach (var singleInstruction in extractedInstructions)
                {

                    if (singleInstruction.Length == 2)
                    {
                        if (singleInstruction[0] == 'n')
                            shiftToBot += -1;
                        else
                            shiftToBot += 1;

                        if (singleInstruction[1] == 'e')
                            shiftToRight += -1;
                        else
                            shiftToRight += 1;
                    }
                    else
                    {
                        if (singleInstruction[0] == 'e')
                            shiftToRight += -2;
                        else
                            shiftToRight += 2;
                    }
                }
                titleLocation.Add(new Tuple<int, int>(shiftToBot, shiftToRight));
            }

            var tiles = titleLocation.GroupBy(
                i => i,
                i => i,
                  (keys, numbersGrouped) =>
                    new Tuple<int, int, bool>(keys.Item1, keys.Item2, (numbersGrouped.Count() % 2 == 1)))
                    .ToList();

            var min1 = tiles.Min(t => t.Item1);
            var min2 = tiles.Min(t => t.Item2);
            var max1 = tiles.Max(t => t.Item1);
            var max2 = tiles.Max(t => t.Item2);

            for (int i = 0; i < 300; i++)
                for (int j = 0; j < 600; j++)
                    if (tiles.Any(t => t.Item1 + 150 == i && t.Item2 + 300 == j && t.Item3))
                        hex[i, j] = true;
                    else
                        hex[i, j] = false;


            solution = CountBlack();

            var adjecentPairs = new List<Tuple<int, int>>()
                    {
                        new Tuple<int, int>(-1,-1),
                        new Tuple<int, int>(-1,1),
                        new Tuple<int, int>(0,-2),
                        new Tuple<int, int>(0,2),
                        new Tuple<int, int>(1,-1),
                        new Tuple<int, int>(1,1),
                    };
            for (int i = 0; i < 100; i++)
            {
                var listOfFilesToChangeState = new List<Tuple<int, int>>();
                for (int hi = 1; hi < 299; hi++)
                {
                    int hj = 2 + (hi % 2);
                    for (; hj < 598; hj += 2)
                    {
                        var adjecentTiles = 0;
                        foreach (var adjectentTile in adjecentPairs)
                        {
                            if (hex[hi + adjectentTile.Item1, hj + adjectentTile.Item2])
                                adjecentTiles++;
                        }

                        if (hex[hi, hj] && (adjecentTiles == 0 || adjecentTiles > 2))
                            listOfFilesToChangeState.Add(new Tuple<int, int>(hi, hj));

                        if (!hex[hi, hj] && adjecentTiles == 2)
                            listOfFilesToChangeState.Add(new Tuple<int, int>(hi, hj));
                    }
                }

                foreach (var toChangeState in listOfFilesToChangeState)
                    hex[toChangeState.Item1, toChangeState.Item2] = !hex[toChangeState.Item1, toChangeState.Item2];

                solution = CountBlack();
            }
        }

        public override void DeliverResults()
        {
        }

        private ulong CountBlack()
        {
            ulong nr = 0;
            for (int i = 0; i < 300; i++)
                for (int j = 0; j < 600; j++)
                    if (hex[i, j])
                        nr++;

            return nr;
        }

        private List<string> ExtractTnstructions(string instruction)
        {
            var instructions = new List<string>();

            for (int i = 0; i < instruction.Length;)
            {
                var instructionLength = 1;
                if (instruction[i] == 's' || instruction[i] == 'n')
                    instructionLength = 2;

                var singleinstruction = instruction.Substring(i, instructionLength);
                instructions.Add(singleinstruction);
                i += instructionLength;
            }

            return instructions;
        }
    }
}