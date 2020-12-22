using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day17
{
    public interface IDimension
    {
        public int GetNumberOfActiveCubes();
        public bool ChangeState();
    }
}
