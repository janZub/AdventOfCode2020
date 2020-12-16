
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day8
{
    public class PuzzleSolverDay8
    {
        public int CountAccumulator(List<CommandDay8> commands)
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
        public CommandDay8b FindCommandThatCauseInfiniteLoopData(List<CommandDay8> commands)
        {
            var listOfChangableNodes = commands.Where(c => c is CommandDay8b).Select(c => (CommandDay8b)c).ToList();

            for (int i = 0; i < listOfChangableNodes.Count; i++)
            {
                listOfChangableNodes[i].ChangeCommand();
                if (GoesToEnd(commands))
                {
                    listOfChangableNodes[i].ChangeCommand();
                    return listOfChangableNodes[i];
                }
                else
                    listOfChangableNodes[i].ChangeCommand();
            }
            throw new Exception("Cannot fix with change of 1 node.");
        }
        private bool GoesToEnd(List<CommandDay8> commands)
        {
            var visitedNodes = new HashSet<int>();

            var currentNode = 0;
            var maxNode = commands.Count - 1;
            while (true)
            {
                if (currentNode > maxNode || currentNode < 0)
                    return true;

                var currentCommand = commands[currentNode];

                if (!visitedNodes.Add(currentNode))
                    return false;

                if (currentCommand.Command == CommandDay8Enum.jmp)
                    currentNode += currentCommand.CommandValue;
                else
                    currentNode++;
            }

        }
    }
}