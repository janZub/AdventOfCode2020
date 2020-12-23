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
        protected string inputFileileName = "Day22Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected GameDay22 game;

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            var player2Starts = input.FindIndex(s => s == "Player 2:");
            var player1Cards = input.Skip(1).Take(player2Starts - 2).Select(s => int.Parse(s)).ToList();
            var player2Cards = input.Skip(player2Starts + 1).Select(s => int.Parse(s)).ToList();

            game = new GameDay22(player1Cards, player2Cards);
        }
        public override void Solve()
        {
            while (!game.GameEnded())
                game.PlayRound();

            solution = game.GetWinnerScore();
        }
        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Winner score is: {0}.", solution));

        }
    }
}