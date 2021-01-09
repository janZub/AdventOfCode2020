using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day21
{
    public class PuzzleDay21b : PuzzleDay21
    {
        private string solution;
        public override void Solve()
        {
            var allergenWithSingleIngredient = GetSingleIngredientForAllergent();
            solution = string.Join(',', allergenWithSingleIngredient.OrderBy(i => i.Key).Select(i => i.Value).ToList());
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("The answer is {0}.", solution));
        }
    }
}