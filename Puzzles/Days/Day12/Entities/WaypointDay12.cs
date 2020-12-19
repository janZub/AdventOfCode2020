using System;

namespace Puzzles.Day12
{
    public class WaypointDay12 : MovableObjectDay12
    {
        public WaypointDay12()
        {
            PositionX = 1;
            PositionY = 10;
        }
        public void ExecuteRotationManeuver(int rotationValue)  
        {
            var turns = ChangeRotationToPerpendicularTurns(rotationValue);

            if (turns == 0)
                return;

            if (turns == 1)
            {
                var positionHold = PositionX;
                PositionX = (-1) * PositionY;
                PositionY = positionHold;
            }
            if (turns == 2)
            {
                PositionX = (-1) * PositionX;
                PositionY = (-1) * PositionY;
            }
            if (turns == 3)
            {
                var positionHold = PositionX;
                PositionX = PositionY;
                PositionY = (-1) * positionHold;
            }
        }
    }
}
