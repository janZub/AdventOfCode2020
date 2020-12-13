using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day4
{
    public class InputHandlerDay4a
    {
        public List<Passport> CreatePassporsFromInput(List<string> lines)
        {
            var passportList = new List<Passport>();
            var passportLines = new List<string>();

            for (int i = 0; i < lines.Count; i++)
            {
                passportLines.Add(lines[i]);

                if (string.IsNullOrWhiteSpace(lines[i]) || i + 1 == lines.Count)
                {
                    passportList.Add(new Passport(passportLines));
                    passportLines = new List<string>();
                }
            }
            return passportList;
        }
    }
}