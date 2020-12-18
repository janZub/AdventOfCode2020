using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day11
{
    public class InVisionNeighbourStrategy : ISittingStrategy
    {
        public bool ShouldChangeState(SeatDay11 seat, int neighbours)
        {
            if (neighbours >= 5 && seat.IsOccupied())
                return true;

            else if (neighbours == 0 && seat.IsEmpty())
                return true;

            return false;
        }
        public int CountOccupiedNeighbours(SeatDay11[,] seats, int i, int j)
        {
            var neighboursCount = 0;
            for (int directionX = -1; directionX <= 1; directionX++)
            {
                for (int directionY = -1; directionY <= 1; directionY++)
                {
                    if (SeeNeighbourInDirection(seats, i, j, directionX, directionY))
                        neighboursCount++;
                }
            }

            return neighboursCount;
        }
        private bool SeeNeighbourInDirection(SeatDay11[,] seats, int seatIndexColumn, int seatIndexRow, int directionX, int directionY)
        {
            var xPositionsToSearch = PostionsToSearch(directionX, seats.GetLength(0), seatIndexColumn);
            var yPositionsToSearch = PostionsToSearch(directionY, seats.GetLength(1), seatIndexRow);
            var numberOfSearches = NumberOfSearches(directionX, directionY, xPositionsToSearch, yPositionsToSearch);

            for (int i = 1; i <= numberOfSearches; i++)
            {
                var neighbourXIndex = seatIndexColumn - i * directionX;
                var neighbourYIndex = seatIndexRow - i * directionY;

                if (!seats[neighbourXIndex, neighbourYIndex].IsFloor())
                    return seats[neighbourXIndex, neighbourYIndex].IsOccupied();

            }
            return false;
        }

        private int PostionsToSearch(int direction, int length, int seatIndex)
        {
            int positionsToSearch;
            if (direction == -1) // below or right
                positionsToSearch = length - 1 - seatIndex;
            else //up or left
                positionsToSearch = seatIndex;

            return positionsToSearch;
        }
        private int NumberOfSearches(int directionX, int directionY, int positionsX, int positionsY)
        {
            int numberOfSearches;
            if (directionX == 0 && directionY == 0)
                numberOfSearches = 0;
            else if (directionX == 0)
                numberOfSearches = positionsY;
            else if (directionY == 0)
                numberOfSearches = positionsX;
            else
                numberOfSearches = TakeMin(positionsX, positionsY);

            return numberOfSearches;
        }
        private int TakeMin(int a, int b)
        {
            if (a > b)
                return b;

            return a;
        }

    }
}