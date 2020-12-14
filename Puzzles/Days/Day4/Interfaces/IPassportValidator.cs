using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day4
{
    public interface IPassportValidator
    {
        public bool IsPropertyValid(string[] match, string property);
    }
}
