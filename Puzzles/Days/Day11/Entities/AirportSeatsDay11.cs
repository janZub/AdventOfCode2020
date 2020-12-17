using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Day11
{
    public class AirportSeatsDay11
    {
        private char[,] seats;
        private int width;
        private int height;

        public AirportSeatsDay11(char[,] airportSeats)
        {
            seats = airportSeats;
            height = airportSeats.GetLength(0);
            width = airportSeats.GetLength(1);
        }

        public int GetNumberOfOccupiedSeats()
        {
            var numberOfOccupiedSeats = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (IsSeatOccupied(i, j))
                        numberOfOccupiedSeats++;
                }
            }
            return numberOfOccupiedSeats;
        }
        public bool ChangeState()
        {
            var seatsToChangeState = GetSeatsToChange();
            foreach (var seat in seatsToChangeState)
                ChangeState(seat.Item1, seat.Item2);

            if (seatsToChangeState.Count > 0)
                return true;

            return false;
        }

        private List<Tuple<int, int>> GetSeatsToChange()
        {
            var seatToChange = new List<Tuple<int, int>>();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (IsFloor(i, j))
                        continue;

                    var occupiedNeighbours = CountOccupiedNeighbours(i, j);
                    var isOccupied = IsSeatOccupied(i, j);

                    if (occupiedNeighbours >= 4 && isOccupied)
                        seatToChange.Add(new Tuple<int, int>(i, j));

                    else if (occupiedNeighbours == 0 && !isOccupied)
                        seatToChange.Add(new Tuple<int, int>(i, j));
                }
            }

            return seatToChange;
        }
        private int CountOccupiedNeighbours(int i, int j)
        {
            var occupiedSeats = 0;
            for (int i2 = i - 1; i2 <= i + 1; i2++)
            {
                for (int j2 = j - 1; j2 <= j + 1; j2++)
                {
                    if (IsSeatOccupied(i2, j2))
                        occupiedSeats++;
                }
            }

            if (IsSeatOccupied(i, j))
                occupiedSeats--;

            return occupiedSeats;
        }
        private bool IsSeatOccupied(int i, int j)
        {
            if (i < 0 || j < 0 || i > height - 1 || j > width - 1)
                return false;

            if (seats[i, j] == '#')
                return true;

            return false;
        }
        private bool IsFloor(int i, int j)
        {
            return seats[i, j] == '.';
        }
        private void ChangeState(int i, int j)
        {
            if (seats[i, j] == 'L')
                seats[i, j] = '#';

            else if (seats[i, j] == '#')
                seats[i, j] = 'L';
        }

        public void PrintSeats()
        {
            for (int i = 0; i < height; i++)
            {
                var line = "";
                for (int j = 0; j < width; j++)
                    line += (seats[i, j]);

                Console.WriteLine(line);
            }
        }
    }
}