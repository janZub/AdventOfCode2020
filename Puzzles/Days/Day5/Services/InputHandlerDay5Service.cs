using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day5
{
    public class InputHandlerDay5Service
    {
        public List<SeatDay5> CreateSeatsFromInput(List<string> input)
        {
            var seats = new List<SeatDay5>();
            foreach (var seatCode in input)
                seats.Add(new SeatDay5(seatCode));

            return seats;
        }
    }
}
