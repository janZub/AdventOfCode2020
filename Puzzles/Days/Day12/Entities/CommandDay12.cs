using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day12
{
    public class CommandDay12
    {
        public virtual DirectionDay12Enum Direction { get; private set; }
        public virtual CommandTypeDay12Enum CommandType { get; private set; }
        public virtual int ActionValue { get; private set; }
        public static CommandDay12 CreateCommand(string commandString)
        {
            var command = new CommandDay12();
            command.SetCommand(commandString);

            return command;
        }

        private void SetCommand(string commandString)
        {

            if (string.IsNullOrWhiteSpace(commandString) || !int.TryParse(commandString.Substring(1), out int action))
                throw new Exception("Expected Cxxx where xxx are digits.");

            ActionValue = action;

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
                        CommandType = CommandTypeDay12Enum.RotateRight;
                        ActionValue = 360 - ActionValue % 360;

                        break;
                    }
                case 'R':
                    {
                        CommandType = CommandTypeDay12Enum.RotateRight;
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