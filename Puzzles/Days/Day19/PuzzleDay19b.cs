using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day19
{
    public class PuzzleDay19b : PuzzleDay19
    {
        public override void ReadInput()
        {
            base.ReadInput();
            inputHandler.UpgradeRule8(rules.First(r => r.Id == 8));
            inputHandler.UpgradeRule11(rules.First(r => r.Id == 11));
        }
    }
}