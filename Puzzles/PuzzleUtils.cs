using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace Puzzles
{
    public static class PuzzleUtils
    {
        public static string PuzzleInputsPath
        {
            get => string.Format("{0}/../{1}", AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")), "Puzzles/Inputs");
        }
    }
}