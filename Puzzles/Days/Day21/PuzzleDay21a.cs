using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day19
{
    public class PuzzleDay21a : Puzzle
    {
        protected ulong solution;
        protected List<Tuple<List<string>, List<string>>> ingAll = new List<Tuple<List<string>, List<string>>>();
        protected string inputFileileName = "Day21Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            foreach (var line in input)
            {
                ingAll.Add(GetIngredientsAndAllergens(line));
            }
        }
        public override void Solve()
        {
            var possibleAllergens = ingAll.Select(i => i.Item2).Aggregate((i, j) => i.Union(j).ToList());
            var possibleIngredients = ingAll.Select(i => i.Item1).Aggregate((i, j) => i.Union(j).ToList());
            var ingalgDict = new Dictionary<string, List<string>>();

            foreach (var aller in possibleAllergens)
            {
                var allerIng = ingAll.Where(i => i.Item2.Contains(aller)).Select(i => i.Item1).Aggregate((i, j) => i.Intersect(j).ToList());

                ingalgDict.Add(aller, allerIng);
            }

            while (ingalgDict.Any(e => e.Value.Count != 1))
            {
                var foundAllergs = ingalgDict.Where(i => i.Value.Count == 1).Select(i => i.Value).Aggregate((i, j) => i.Union(j).ToList());
                var noFoundAllergsKey = ingalgDict.Where(i => i.Value.Count > 1).Select(i => i.Key).ToList();

                foreach (var notFoundAllergs in noFoundAllergsKey)
                {
                    ingalgDict[notFoundAllergs] = ingalgDict[notFoundAllergs].Except(foundAllergs).ToList();
                }
            }
            var dangerousIngredients = ingalgDict.OrderBy(i=>i.Key).Select(i => i.Value.First()).ToList();

            var dangerousIngredientsList = string.Join(',',ingalgDict.OrderBy(i => i.Key).Select(i => i.Value.First()).ToList());

            ingAll.ForEach(i => solution += (ulong)i.Item1.Except(dangerousIngredients).Count());
        }
        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Number of valid ingredients is {0}.", solution));

        }
        private Tuple<List<string>, List<string>> GetIngredientsAndAllergens(string input)
        {
            var ingAndAller = input.Split('(');
            var ing = ingAndAller[0].Split(' ').Where(s=>!string.IsNullOrWhiteSpace(s)).Select(s=>s.Trim()).ToList();
            var aller = ingAndAller[1].Remove(ingAndAller[1].Length - 1).Split(' ').Skip(1).Select(s => s.Replace(",","").Trim()).ToList();
            var newEntry = new Tuple<List<string>, List<string>>(ing,aller);

            return newEntry;
        }
    }
}