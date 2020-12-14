using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day4
{
    public class PassportPropertyValidator : IPassportValidator
    {
        public bool IsPropertyValid(string[] match, string property)
        {


            var pattern = GetPatterForProperty(property);
            var isValid = Regex.IsMatch(match[1], pattern);

            return isValid;
        }
        private string GetPatterForProperty(string property)
        {
            string pattern;
            switch (property)
            {
                case "byr":
                    pattern = "^((19[2-9][0-9])|(200[0-2]))$";
                    break;
                case "iyr":
                    pattern = "^(20((1[0-9])|(20)))$";
                    break;
                case "eyr":
                    pattern = "^(20((2[0-9])|(30)))$";
                    break;
                case "hcl":
                    pattern = "^(#[0-9a-f]{6})$";
                    break;
                case "ecl":
                    pattern = "^(amb|blu|brn|gry|grn|hzl|oth)$";
                    break;
                case "pid":
                    pattern = "^[0-9]{9}$";
                    break;
                case "hgt":
                    pattern = "^(((1(([5-8][0-9])|([9][0-3])))cm)|((59)|([6][0-9])|([7][0-6]))in)$";
                    break;
                default:
                    throw new ArgumentException("No pattern for property.", "property");
            }

            return pattern;
        }
    }
}