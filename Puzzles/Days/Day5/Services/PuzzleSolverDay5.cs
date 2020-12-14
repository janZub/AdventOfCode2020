
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day5
{
    public class PuzzleSolverDay5
    {
        public int GetMaxSeatId(List<Seat> seats)
        {
            return GetListOfSeatIds(seats).Max();
        }
        public List<int> GetListOfSeatIds(List<Seat> seats)
        {
            var seatIds = new List<int>();

            foreach (var seat in seats)
                seatIds.Add(seat.GetSeatId());

            return seatIds;
        }
        public int GetMissingId(List<Seat> seats)
        {
            var seatsIds = GetListOfSeatIds(seats).OrderBy(i => i).ToList();

            for (int i = 0; i < seatsIds.Count - 1; i++)
            {
                if (seatsIds[i] + 2 == seatsIds[i + 1])
                    return seatsIds[i] + 1;
            }

            throw new Exception("Seat not found.");
        }
    }
}