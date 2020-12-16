
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day8
{
    public class PuzzleSolverDay8
    {
        public int CountAccumulatorUntilInfiniteLoop(List<CommandDay8> commands)
        {
            int accumulator = 0;
            var visitedNodes = new HashSet<int>();
            var currentNode = 0;
            var maxNode = commands.Count - 1;
            while (true)
            {

                if (currentNode > maxNode || currentNode < 0)
                    return accumulator;

                var currentCommand = commands[currentNode];

                if (!visitedNodes.Add(currentNode))
                    break;

                if (currentCommand.Command == CommandDay8Enum.acc)
                    accumulator += currentCommand.CommandValue;

                if (currentCommand.Command == CommandDay8Enum.jmp)
                    currentNode += currentCommand.CommandValue;
                else
                    currentNode++;
            }


            return accumulator;
        }
    }
}