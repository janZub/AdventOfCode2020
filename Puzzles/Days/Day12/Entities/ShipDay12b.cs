using System;

namespace Puzzles.Day12
{
    public class ShipDay12b : MovableObjectDay12, ICommandable
    {
        private WaypointDay12 waypoint = new WaypointDay12();
        public ShipDay12b()
        {
            PositionX = 0;
            PositionY = 0;
        }

        public void ExecuteCommand(CommandDay12 command)
        {
            switch (command.CommandType)
            {
                case CommandTypeDay12Enum.Forward:
                    MoveTowardsWaypoint(command.ActionValue);
                    break;
                case CommandTypeDay12Enum.RotateRight:
                    waypoint.ExecuteRotationManeuver(command.ActionValue);
                    break;
                case CommandTypeDay12Enum.IntoDirection:
                    waypoint.MoveIntoDirection(command.Direction, command.ActionValue);
                    break;
                default:
                    throw new Exception("Unknown commnad");
            }
        }
        private void MoveTowardsWaypoint(int forwardValue)
        {
            PositionX = PositionX + (waypoint.PositionX * forwardValue);
            PositionY = PositionY + (waypoint.PositionY * forwardValue);
        }
    }
}