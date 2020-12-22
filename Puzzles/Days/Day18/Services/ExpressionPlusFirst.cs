using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day18
{
    public class ExpressionPlusFirst : ExpressionSolverService
    {
        protected static string findPlusOperaion = @"([\d]+)(?:\s\+\s([\d]+))+";
        protected static string findMultipleOperaion = @"([\d]+)";

        public override string SolveSimpleExpression(string expression)
        {
            expression = SolvePlusExpressions(expression);
            expression = SolveMultiplyExpressions(expression);

            return expression;
        }

        private string SolvePlusExpressions(string expression)
        {
            while (true)
            {
                var elements = Regex.Matches(expression, findPlusOperaion);

                if (elements.Count == 0)
                    break;

                var subset = elements[0];
                ulong reducedSubset = ulong.Parse(subset.Groups[1].Value);
          
                for (int j = 0; j < subset.Groups[2].Captures.Count; j++)
                    reducedSubset += ulong.Parse(subset.Groups[2].Captures[j].Value);


                var aStringBuilder = new StringBuilder(expression);
                aStringBuilder.Remove(subset.Index, subset.Length);
                aStringBuilder.Insert(subset.Index, reducedSubset);
                expression = aStringBuilder.ToString();
            }

            return expression;
        }
        private string SolveMultiplyExpressions(string expression)
        {
            var me = Regex.Matches(expression, findMultipleOperaion);
            if (me.Count == 0)
                return expression.ToString();

            ulong result = 1;
            for (int i = 0; i < me.Count; i++)
                result *= ulong.Parse(me[i].Value);

            return result.ToString();
        }

    }
}