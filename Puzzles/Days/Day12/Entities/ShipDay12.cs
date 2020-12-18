using System;

namespace Puzzles.Day12
{
    public class ShipDay12
    {
        private int positionX;
        private int positionY;

        private DirectionDay12Enum facingDirection;

        public ShipDay12()
        {
            positionX = 0;
            positionY = 0;
            facingDirection = DirectionDay12Enum.East;
        }

        public void ExecuteCommand(CommandDay12 command)
        {
            switch (command.CommandType)
            {
                case CommandTypeDay12Enum.Forward:
                    MoveIntoDirection(facingDirection, command.ActionValue);
                    break;
                case CommandTypeDay12Enum.Rotate:
                    ExecuteRotationManeuver(command.ActionValue);
                    break;
                case CommandTypeDay12Enum.IntoDirection:
                    MoveIntoDirection(command.Direction, command.ActionValue);
                    break;
                default:
                    throw new Exception("Unknown commnad");
            }
        }
        public int GetManhattanDistance()
        {
            return Math.Abs(positionX) + Math.Abs(positionY);
        }
        private void ExecuteRotationManeuver(int rotationValue)
        {
            rotationValue = (rotationValue % 360) / 90;
            facingDirection = (DirectionDay12Enum)(((int)facingDirection + rotationValue) % 4);
        }
        private void MoveIntoDirection(DirectionDay12Enum direction, int actionValue)
        {
            switch (direction)
            {
                case DirectionDay12Enum.West:
                    positionY += actionValue;
                    break;
                case DirectionDay12Enum.South:
                    positionX -= actionValue;
                    break;
                case DirectionDay12Enum.East:
                    positionY -= actionValue;
                    break;
                case DirectionDay12Enum.North:
                    positionX += actionValue;
                    break;
                default:
                    throw new Exception("Unknown Command");
            }
        }
    }
}