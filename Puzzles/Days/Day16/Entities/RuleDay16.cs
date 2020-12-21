using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day16
{
    public class RuleDay16
    {
        public List<Tuple<int, int>> Ranges { get; set; }
        public string Name { get; private set; }
        public RuleDay16(string name)
        {
            Ranges = new List<Tuple<int, int>>();
            Name = name;
        }
        public void AddRange(int min, int max)
        {
            if (min > max)
                throw new Exception("Min must me <= than max.");

            Ranges.Add(new Tuple<int, int>(min, max));
        }

        public bool IsNumberValid(int number)
        {
            foreach (var range in Ranges)
            {
                if (number >= range.Item1 && number <= range.Item2)
                {
                    return true;
                }
            }
            return false;
        }
    }
}