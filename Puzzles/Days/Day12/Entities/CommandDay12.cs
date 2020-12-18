using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day12
{
    public class CommandDay12
    {
        public DirectionDay12Enum Direction { get; private set; }
        public CommandTypeDay12Enum CommandType { get; private set; }
        public int ActionValue { get; private set; }

        public CommandDay12(string commandString)
        {
            SetCommand(commandString);
        }
        private void SetCommand(string commandString)
        {
            ActionValue = int.Parse(commandString.Substring(1));
            
            switch (commandString[0])
            {
                case 'N':
                    {
                        CommandType = CommandTypeDay12Enum.IntoDirection;
                        Direction = DirectionDay12Enum.North;
                        break;
                    }
                case 'S':
                    {
                        CommandType = CommandTypeDay12Enum.IntoDirection;
                        Direction = DirectionDay12Enum.South;
                        break;
                    }
                case 'W':
                    {
                        CommandType = CommandTypeDay12Enum.IntoDirection;
                        Direction = DirectionDay12Enum.West;
                        break;
                    }
                case 'E':
                    {
                        CommandType = CommandTypeDay12Enum.IntoDirection;
                        Direction = DirectionDay12Enum.East;
                        break;
                    }
                case 'L':
                    {
                        CommandType = CommandTypeDay12Enum.Rotate;
                        ActionValue = 360 - ActionValue%360;

                        break;
                    }
                case 'R':
                    {
                        CommandType = CommandTypeDay12Enum.Rotate;
                        break;
                    }
                case 'F':
                    {
                        CommandType = CommandTypeDay12Enum.Forward;
                        break;
                    }
                default:
                    throw new Exception("Unknown command.");

            }
        }

    }
}
