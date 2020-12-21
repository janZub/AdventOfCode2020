using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day17
{
    public class CubeDay17
    {
        public char CubeState { get; private set; }

        public CubeDay17(char state)
        {
            CubeState = state;
        }
        public bool IsOccupied()
        {
            return CubeState == '#';
        }
        public bool IsEmpty()
        {
            return CubeState == '.';
        }
        public bool ChangeState()
        {
            if (IsOccupied())
                CubeState = '.';
            else if (IsEmpty())
                CubeState = '#';

            return true;
        }
    }
}