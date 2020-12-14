
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day4
{
    public class PuzzleSolverDay4
    {
        public int CountValidPassports(List<IPassportDay4> passports)
        {
            int validPasswords = 0;
            foreach (var p in passports)
            {
                if (p.IsValid())
                    validPasswords++;
            }
            return validPasswords;
        }
    }
}