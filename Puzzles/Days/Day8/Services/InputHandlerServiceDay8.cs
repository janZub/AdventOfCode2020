using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Puzzles.Day8
{
    public class InputHandlerServiceDay8
    {
        private string pattern = @"^(nop|acc|jmp)\s?([+|-])\s?([\d]+)$";
        public CommandDay8 CreateCommand(string input)
        {
            var properties = GetProperties(input);
            var command = CreateCommand(properties);

            return command;
        }

        //could extract to new class and make these public
        private List<string> GetProperties(string input)
        {
            var match = Regex.Match(input, pattern);

            if (match.Groups.Count != 4)
                throw new Exception("Incorrect number of matched groups");

            var result = match.Groups.Values.Select(gv => gv.Value).ToList();
            result.RemoveAt(0);

            return result;
        }
        private CommandDay8 CreateCommand(List<string> parameters)
        {
            var action = GetAcctionFromParameters(parameters);
            var value = GetValueFromParameters(parameters);

            if (CommandDay8.IsCommandChangable(action))
                return new CommandDay8b(action, value);
            else
                return new CommandDay8(action, value);
        }
        private int GetValueFromParameters(List<string> parameters)
        {
            var sign = parameters[1];

            if (!int.TryParse(parameters[2], out int value))
                throw new InvalidCastException("3rd match must by number");

            if (sign == "-")
                value *= (-1);
            else if (sign != "+")
                throw new Exception("Expected - or + in 3rd parameter");

            return value;
        }
        private CommandDay8Enum GetAcctionFromParameters(List<string> parameters)
        {
            var action = parameters[0]; ;
            var actionEnum = Enum.Parse(typeof(CommandDay8Enum), action);

            if (actionEnum is CommandDay8Enum)
                return (CommandDay8Enum)actionEnum;
            else
                throw new Exception("Unknown command");
        }
    }
}