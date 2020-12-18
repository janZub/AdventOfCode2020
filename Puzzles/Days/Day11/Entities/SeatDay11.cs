using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day11
{
    public class SeatDay11
    {
        public char SeatState { get; private set; }

        public SeatDay11(char state)
        {
            SeatState = state;
        }
        public bool IsFloor()
        {
            return SeatState == '.';
        }
        public bool IsOccupied()
        {
            return SeatState == '#';
        }
        public bool IsEmpty()
        {
            return SeatState == 'L';
        }
        public bool ChangeState()
        {
            var changedState = false;
            if (SeatState == 'L')
            {
                SeatState = '#';
                changedState = true;
            }
            else if (SeatState == '#')
            {
                SeatState = 'L';
                changedState = true;
            }

            return changedState;
        }
    }
}