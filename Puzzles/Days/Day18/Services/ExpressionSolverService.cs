using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day18
{
    public abstract class ExpressionSolverService : IExpressionSolver
    {
        protected static string patternInnerParanthesses = @"\(([\d\s\*\+]+)\)";
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
        public abstract string SolveSimpleExpression(string expression);
    }
}