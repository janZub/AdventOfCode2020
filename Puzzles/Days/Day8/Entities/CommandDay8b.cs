using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day8
{
    public class CommandDay8b : CommandDay8
    {
        public CommandDay8b(CommandDay8Enum commandEnum, int commandValue) : base(commandEnum, commandValue) { }
        public void ChangeCommand()
        {
            switch (Command)
            {
                case CommandDay8Enum.jmp:
                    Command = CommandDay8Enum.nop;
                    break;
                case CommandDay8Enum.nop:
                    Command = CommandDay8Enum.jmp;
                    break;
                default:
                    throw new Exception("Object do not have changable command.");
            }
        }
    }
}