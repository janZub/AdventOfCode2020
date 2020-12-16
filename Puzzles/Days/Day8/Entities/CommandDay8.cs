using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day8
{
    public class CommandDay8
    {
        public CommandDay8Enum Command { get; protected set; }
        public int CommandValue { get; protected set; }

        private static List<CommandDay8Enum> ChangableCommands = new List<CommandDay8Enum>() { CommandDay8Enum.jmp, CommandDay8Enum.nop };


        public CommandDay8(CommandDay8Enum commandEnum, int commandValue)
        {
            Command = commandEnum;
            CommandValue = commandValue;
        }

        public static bool IsCommandChangable(CommandDay8Enum command)
        {
            return ChangableCommands.Contains(command);
        }
    }
}