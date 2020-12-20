using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day14
{
    public class InputHandlerServiceDay14
    {
        private static string pattern = @"mem\[([\d]+)\]\s\=\s([\d]+)";
        public static MemoryInputDay14 CreateMemoryInput(int order, string line, IMask mask)
        {
            var matches = Regex.Match(line, pattern);
            var memory = int.Parse(matches.Groups[1].Value);
            var number = ulong.Parse(matches.Groups[2].Value);

            var memoryInputData = new MemoryInputDay14(number, memory, order, mask);

            return memoryInputData;

        }
        public static string ExtractMask(string line)
        {
            return line.Substring(7).Trim();
        }
        public static bool IsMask(string line)
        {
            return line.StartsWith("mask");
        }
    }
}