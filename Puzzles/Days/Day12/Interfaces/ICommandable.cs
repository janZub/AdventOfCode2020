using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day12
{
    public interface ICommandable
    {
        public void ExecuteCommand(CommandDay12 command);
    }
}
