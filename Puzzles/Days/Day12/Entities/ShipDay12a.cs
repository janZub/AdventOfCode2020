using System;

namespace Puzzles.Day12
{
    public class ShipDay12a : MovableObjectDay12, ICommandable
    {
        private DirectionDay12Enum facingDirection;
        public ShipDay12a()
        {
            PositionX = 0;
            PositionY = 0;
            facingDirection = DirectionDay12Enum.East;
        }

        public void ExecuteCommand(CommandDay12 command)
        {
            switch (command.CommandType)
            {
                case CommandTypeDay12Enum.Forward:
                    MoveIntoDirection(facingDirection, command.ActionValue);
                    break;
                case CommandTypeDay12Enum.RotateRight:
                    ExecuteRotationManeuver(command.ActionValue);
                    break;
                case CommandTypeDay12Enum.IntoDirection:
                    MoveIntoDirection(command.Direction, command.ActionValue);
                    break;
                default:
                    throw new Exception("Unknown commnad");
            }
        }
        private void ExecuteRotationManeuver(int rotationValue)
        {
            facingDirection = GetDirectionAfterRotation(facingDirection, rotationValue);
        }
    }
}