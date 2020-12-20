using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day14
{
    public interface IMask
    {
        public char[] ApplyMask(char[] number);
    }
}
