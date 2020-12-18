using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Day11
{
    public class AirportSeatsDay11
    {
        private SeatDay11[,] seats;
        private int width;
        private int height;

        private ISittingStrategy strategy;

        public AirportSeatsDay11(ISittingStrategy sittingStrategy, SeatDay11[,] airportSeats)
        {
            seats = airportSeats;
            height = airportSeats.GetLength(0);
            width = airportSeats.GetLength(1);

            strategy = sittingStrategy;
        }

        public int GetNumberOfOccupiedSeats()
        {
            var numberOfOccupiedSeats = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (seats[i, j].IsOccupied())
                        numberOfOccupiedSeats++;
                }
            }
            return numberOfOccupiedSeats;
        }
        public bool ChangeState()
        {
            var seatsToChangeState = GetSeatsToChange();
            var changedSeats = false;

            foreach (var seat in seatsToChangeState)
            {
                if (seat.ChangeState())
                    changedSeats = true;
            }

            return changedSeats;
        }

        public void PrintSeats()
        {
            for (int i = 0; i < height; i++)
            {
                var line = "";
                for (int j = 0; j < width; j++)
                    line += seats[i, j].SeatState;

                Console.WriteLine(line);
            }
        }

        private List<SeatDay11> GetSeatsToChange()
        {
            var seatToChange = new List<SeatDay11>();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var seat = seats[i, j];
                    var occupiedNeighbours = strategy.CountOccupiedNeighbours(seats, i, j);

                    if (strategy.ShouldChangeState(seat, occupiedNeighbours))
                        seatToChange.Add(seat);
                }
            }

            return seatToChange;
        }

    }
}