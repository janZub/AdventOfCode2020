using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Day21
{
    public class PuzzleSolverDay21
    {
        public List<string> GetPossibleIngredients(List<DishDay21> dishes)
        {
            return dishes.Select(i => i.Ingredients).Aggregate((i, j) => i.Union(j).ToList());
        }
        public List<string> GetPossibleAllergens(List<DishDay21> dishes)
        {
            return dishes.Select(i => i.Allergens).Aggregate((i, j) => i.Union(j).ToList());
        }

        public Dictionary<string, List<string>> GetAllergensWithPossibleIngredients(List<DishDay21> dishes, List<string> possibleAllergens)
        {
            var ingalgDict = new Dictionary<string, List<string>>();

            foreach (var aller in possibleAllergens)
            {
                var allerIng = dishes.Where(i => i.Allergens.Contains(aller)).Select(i => i.Ingredients).Aggregate((i, j) => i.Intersect(j).ToList());
                ingalgDict.Add(aller, allerIng);
            }

            return ingalgDict;
        }

        public Dictionary<string, string> GetSingleIngredientForAllergent(Dictionary<string, List<string>> allergensIngrendients)
        {
            var allergenToOneIngrendient = new Dictionary<string, string>();
            while (allergensIngrendients.Count > allergenToOneIngrendient.Count)
            {
                var notFoundAllergens = allergensIngrendients.Keys.Except(allergenToOneIngrendient.Keys).ToList();

                foreach (var allergent in notFoundAllergens)
                {
                    var ingredients = allergensIngrendients[allergent].Except(allergenToOneIngrendient.Values).ToList();

                    if (ingredients.Count == 1)
                        allergenToOneIngrendient.Add(allergent, ingredients.Single());
                }
            }

            return allergenToOneIngrendient;
        }

        public ulong CountOccurancesOfValidIngredients(List<DishDay21> dishes, List<string> dangerousIngredients)
        {
            ulong solution = 0;
            dishes.ForEach(i => solution += (ulong)i.Ingredients.Except(dangerousIngredients).Count());
           
            return solution;
        }
    }
}