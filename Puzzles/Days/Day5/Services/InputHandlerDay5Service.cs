using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day5
{
    public class InputHandlerDay5Service
    {
        public List<Seat> CreateSeatsFromInput(List<string> input)
        {
            var seats = new List<Seat>();
            foreach (var seatCode in input)
                seats.Add(new Seat(seatCode));

            return seats;
        }
    }
}
