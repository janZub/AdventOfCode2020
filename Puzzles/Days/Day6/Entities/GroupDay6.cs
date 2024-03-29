﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day6
{
    public abstract class GroupDay6 : IGroupDay6
    {
        public string Data { get; private set; }

        public GroupDay6(string data)
        {
            Data = data;
        }

        public abstract int CountDifferentAnswers();
        protected static string pattern = "a|b|c|d|e|f|g|h|i|j|k|l|m|n|o|p|q|r|s|t|u|v|w|x|y|z";
    }
}