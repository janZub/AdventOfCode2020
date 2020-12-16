using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day8
{
    public class CommandDay8
    {
        public CommandDay8Enum Command { get; private set; }
        public int CommandValue { get; private set; }

        public CommandDay8(CommandDay8Enum commandEnum, int commandValue)
        {
            Command = commandEnum;
            CommandValue = commandValue;
        }
    }
}