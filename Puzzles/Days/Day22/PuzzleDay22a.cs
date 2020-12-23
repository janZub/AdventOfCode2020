using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day22
{
    public class PuzzleDay22a : Puzzle
    {
        protected ulong solution;
        protected List<int> player1Cards = new List<int>();
        protected List<int> player2Cards = new List<int>();
        protected string inputFileileName = "Day22Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            var player2Starts = input.FindIndex(s => s == "Player 2:");

            player1Cards = input.Skip(1).Take(player2Starts - 2).Select(s => int.Parse(s)).ToList();
            player2Cards = input.Skip(player2Starts + 1).Select(s => int.Parse(s)).ToList();
        }
        public override void Solve()
        {
            while (!(player1Cards.Count == 0 || player2Cards.Count == 0))
            {
                var p1card = player1Cards.First();
                player1Cards.RemoveAt(0);
                var p2card = player2Cards.First();
                player2Cards.RemoveAt(0);

                if (p2card > p1card)
                {
                    player2Cards.Add(p2card);
                    player2Cards.Add(p1card);
                }
                else
                {
                    player1Cards.Add(p1card);
                    player1Cards.Add(p2card);
                }
            }

            player2Cards =player2Cards.Union(player1Cards).ToList();
            for(int i = 1; i <= player2Cards.Count; i++)
            {
                solution += (ulong)(i * player2Cards[player2Cards.Count - i]);
            }

        }
        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Winner score is: {0}.", solution));

        }
    }
}