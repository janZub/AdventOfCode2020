using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day4
{
    public abstract class PassportDay4 : IPassportDay4
    {
        public string Data { get; }
        public PassportDay4(string data)
        {
            this.Data = data;
        }
        public static List<string> RequiredProperties
        {
            get => new List<string>()
            { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
        }
        public abstract bool IsValid();
   }
}