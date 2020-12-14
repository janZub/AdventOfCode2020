using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day4
{
    public class PassportDay4b : PassportDay4
    {
        private IPassportValidator passportValidator;
        public PassportDay4b(string lines, IPassportValidator passportValidator) : base(lines)
        {
            this.passportValidator = passportValidator;
        }
        public override bool IsValid()
        {
            foreach (var prop in RequiredProperties)
            {
                var match = GetMatch(prop);

                if (!DidFindProperty(match, prop))
                    return false;
                if (!IsPropertyValid(match, prop))
                    return false;
            }
            return true;
        }

        private bool DidFindProperty(Match match, string property)
        {
            if (match == null || match.Groups.Count == 0)
                return false;

            if (match.Groups[1].Value != property)
                return false;

            return true;
        }
        private bool IsPropertyValid(Match match, string prop)
        {
            var groups = ConvertMatchToArray(match);
            return passportValidator.IsPropertyValid(groups, prop);
        }
        private string[] ConvertMatchToArray(Match match)
        {
            return match.Groups.Values.Select(g => g.Value).Skip(1).ToArray();
        }

        private Match GetMatch(string prop)
        {
            var match = Regex.Match(Data, GetPropertyPattern(prop));
            return match;
        }
        private string GetPropertyPattern(string prop)
        {
            return string.Format(@"({0}):([^\s]*)", prop);
        }
    }
}