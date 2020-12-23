using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day22
{
    public class PuzzleDay22b : PuzzleDay22
    {
        protected override IGame CreateGame(List<int> player1Cards, List<int> player2Cards)
        {
            return new RecursiveCombatDay22(player1Cards, player2Cards);
        }
    }
}