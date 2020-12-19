using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day12
{
    public class MovableObjectDay12: IMovable
    {
        public virtual long PositionX { get; protected set; }
        public virtual long PositionY { get; protected set; }

        public virtual long GetManhattanDistance()
        {
            return Math.Abs(PositionX) + Math.Abs(PositionY);
        }
        public void MoveIntoDirection(DirectionDay12Enum direction, int actionValue)
        {
            switch (direction)
            {
                case DirectionDay12Enum.West:
                    PositionY -= actionValue;
                    break;
                case DirectionDay12Enum.South:
                    PositionX -= actionValue;
                    break;
                case DirectionDay12Enum.East:
                    PositionY += actionValue;
                    break;
                case DirectionDay12Enum.North:
                    PositionX += actionValue;
                    break;
                default:
                    throw new Exception("Unknown Command");
            }
        }

        protected DirectionDay12Enum GetDirectionAfterRotation(DirectionDay12Enum direction, int rotationValue)
        {
            rotationValue = ChangeRotationToPerpendicularTurns(rotationValue);
            rotationValue = ((int)direction + rotationValue) % 4;
            return (DirectionDay12Enum)rotationValue;
        }
        protected int ChangeRotationToPerpendicularTurns(int rotationValue)
        {
            rotationValue = (rotationValue % 360) / 90;
            return rotationValue;
        }
    }
}
