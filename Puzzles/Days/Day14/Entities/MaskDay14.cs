using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day14
{
    public abstract class MaskDay14 : IMask
    {
        public char[] Mask { get; protected set; }

        public MaskDay14(string mask)
        {
            Mask = mask.ToCharArray();
        }
        public abstract char[] ApplyMask(char[] number);
    }
}