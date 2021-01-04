using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day24
{
    public class TileDay24
    {
        public bool State { get; private set; }
        public int Neighbours { get; set; }
        public void ChangeState()
        {
            State = !State;
        }
    }
}