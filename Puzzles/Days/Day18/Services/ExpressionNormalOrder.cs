using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day18
{
    public class ExpressionNormalOrder : ExpressionSolverService
    {
        protected static string patternOperations = @"([\d]+)\s?([\*+]?)\s?";

        public override string SolveSimpleExpression(string expression)
        {
            var elements = Regex.Matches(expression, patternOperations);

            var result = ulong.Parse(elements[0].Groups[1].Value);
            for (int i = 1; i < elements.Count; i++)
            {
                var nextElement = ulong.Parse(elements[i].Groups[1].Value.Trim());

                if (elements[i - 1].Groups[2].Value.Trim() == "+")
                    result += nextElement;
                else
                    result *= nextElement;
            }
            return result.ToString();
        }
    }
}