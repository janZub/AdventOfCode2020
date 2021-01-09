using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Day21
{
    public class DishDay21
    {
        public List<string> Ingredients { get; set; }
        public List<string> Allergens { get; set; }
        public DishDay21(string input)
        {
            var ingAndAller = input.Split('(');
            Ingredients = ingAndAller[0].Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => s.Trim()).ToList();
            Allergens = ingAndAller[1].Remove(ingAndAller[1].Length - 1).Split(' ').Skip(1).Select(s => s.Replace(",", "").Trim()).ToList();
        }
    }
}
