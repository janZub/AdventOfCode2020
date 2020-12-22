using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day19
{
    public class RuleToReplaceDay19
    {
        public int Id { get; private set; }
        public int Index { get; private set; }
        public int Length { get; private set; }

        public RuleToReplaceDay19(int id, int index, int length)
        {
            Id = id;
            Index = index;
            Length = length;
        }

    }
}