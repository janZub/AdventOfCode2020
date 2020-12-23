using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day22
{
    public interface IGame
    {
        public void PlayRound();
        public ulong GetWinnerScore();
        public bool GameEnded();
    }
}
