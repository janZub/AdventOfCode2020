using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day11
{
    public class CloseNeighboursStrategy : ISittingStrategy
    {
        public int CountOccupiedNeighbours(SeatDay11[,] seats, int i, int j)
        {
            var occupiedNeighbourSeats = 0;
            var maxColumnIndex = seats.GetLength(0) - 1;
            var maxRowIndex = seats.GetLength(1) - 1;

            for (int m = - 1; m <= 1; m++)
            {
                for (int l = - 1; l <= 1; l++)
                {
                    var neighbourCoulmnIndex = i - m;
                    var neighbourRowIndex = j - l;

                    if (neighbourCoulmnIndex == i && neighbourRowIndex == j)
                        continue;

                    if (neighbourCoulmnIndex < 0 || neighbourCoulmnIndex > maxColumnIndex)
                        continue;

                    if (neighbourRowIndex < 0 || neighbourRowIndex > maxRowIndex)
                        continue;

                    if (seats[neighbourCoulmnIndex, neighbourRowIndex].IsOccupied())
                        occupiedNeighbourSeats++;
                }
            }

            return occupiedNeighbourSeats;
        }

        public bool ShouldChangeState(SeatDay11 seat, int neighbours)
        {
            if (neighbours >= 4 && seat.IsOccupied())
                return true;

            else if (neighbours == 0 && seat.IsEmpty())
                return true;

            return false;
        }
    }
}