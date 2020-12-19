using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day12
{
    public interface IMovable
    {
        public long PositionX { get; }
        public long PositionY { get; }
        public long GetManhattanDistance();
        public void MoveIntoDirection(DirectionDay12Enum direction, int actionValue);
    }
}