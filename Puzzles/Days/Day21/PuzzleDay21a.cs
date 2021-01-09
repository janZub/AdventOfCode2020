using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day21
{
    public class PuzzleDay21a : PuzzleDay21
    {
        protected ulong solution;

        public override void Solve()
        {
            var dangerousIngredients = GetSingleIngredientForAllergent().Select(k => k.Value).ToList();
            solution = solver.CountOccurancesOfValidIngredients(dishes, dangerousIngredients);
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Number of valid ingredients is {0}.", solution));

        }

    }
}