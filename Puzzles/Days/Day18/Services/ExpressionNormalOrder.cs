using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day18
{
    public class ExpressionNormalOrder : IExpressionSolver
    {
        protected static string patternInnerParanthesses = @"\(([\d\s\*\+]+)\)";
        protected static string patternOperations = @"([\d]+)\s?([\*+]?)\s?";

        public ulong Solve(string expression)
        {
            var reducedExpression = ReduceParenthesis(expression);
            var result = SolveSimpleExpression(reducedExpression);

            return ulong.Parse(result);
        }
        protected string ReduceParenthesis(string expression)
        {
            while (true)
            {
                var matches = FindMostInnerParenthesis(expression);
                if (matches.Count == 0)
                    return expression;
                else
                    expression = ReduceParenthesisExpression(matches, expression);
            }
        }
        protected MatchCollection FindMostInnerParenthesis(string expression)
        {
            var matches = Regex.Matches(expression, patternInnerParanthesses);
            return matches;
        }
        protected string ReduceParenthesisExpression(MatchCollection matches, string expression)
        {
            for (int i = 0; i < matches[0].Captures.Count; i++)
            {
                var subset = matches[0].Captures[i];
                var reducedSubset = SolveSimpleExpression(subset.Value);

                var aStringBuilder = new StringBuilder(expression);
                aStringBuilder.Remove(subset.Index, subset.Length);
                aStringBuilder.Insert(subset.Index, reducedSubset);
                expression = aStringBuilder.ToString();
            }

            return expression;
        }
        protected virtual string SolveSimpleExpression(string expression)
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