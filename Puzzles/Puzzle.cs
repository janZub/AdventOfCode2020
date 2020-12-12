using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Puzzles
{
    public abstract class Puzzle
    {
        public abstract void ReadInput();
        public abstract void Solve();
        public abstract void DeliverResults();
    }
}