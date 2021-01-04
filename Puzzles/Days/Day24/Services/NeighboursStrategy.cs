using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day24
{
    public class NeighboursStrategy : INeighboourStrategy
    {
        private static List<Tuple<int, int>> adjecentPairs = new List<Tuple<int, int>>()
                    {
                        new Tuple<int, int>(-1,-1),
                        new Tuple<int, int>(-1,1),
                        new Tuple<int, int>(0,-2),
                        new Tuple<int, int>(0,2),
                        new Tuple<int, int>(1,-1),
                        new Tuple<int, int>(1,1),
                    };

        public int CountOccupiedNeighbours(TileDay24[,] tiles, int i, int j)
        {
            var occupiedNeighbour = 0;

            foreach (var adjectentTile in adjecentPairs)
            {
                var height = i + adjectentTile.Item1;
                var width = j + adjectentTile.Item2;

                if (height < 0 || width < 0)
                    continue;

                if (height >= tiles.GetLength(0) || width >= tiles.GetLength(1))
                    continue;

                if (tiles[height, width].State)
                    occupiedNeighbour++;

            }
            return occupiedNeighbour;
        }

        public bool ShouldChangeState(TileDay24 tile)
        {
            if (tile.Neighbours == 2 && !tile.State)
                return true;

            else if ((tile.Neighbours == 0 || tile.Neighbours > 2) && tile.State)
                return true;

            return false;
        }
    }
}