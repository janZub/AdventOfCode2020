using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day21
{
    public abstract class PuzzleDay21 : Puzzle
    {
        protected List<DishDay21> dishes = new List<DishDay21>();
        protected string inputFileileName = "Day21Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected PuzzleSolverDay21 solver = new PuzzleSolverDay21();
        
        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            foreach (var line in input)
                dishes.Add(new DishDay21(line));
        }

        protected Dictionary<string, string> GetSingleIngredientForAllergent()
        {
            var possibleAllergens = solver.GetPossibleAllergens(dishes);
            var allergensWithPossibleIngredients = solver.GetAllergensWithPossibleIngredients(dishes, possibleAllergens);
            var allergensInIngredients = solver.GetSingleIngredientForAllergent(allergensWithPossibleIngredients);

            return allergensInIngredients;
        }
    }
}