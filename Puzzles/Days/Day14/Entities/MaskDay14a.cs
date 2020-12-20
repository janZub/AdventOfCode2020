using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day14
{
    public class MaskDay14a : MaskDay14
    {
        public MaskDay14a(string mask) : base(mask) { }

        public override char[] ApplyMask(char[] number)
        {
            if (number.Length < 36)
                throw new Exception();

            var result = number;

            for (int i = 0; i < Mask.Length; i++)
            {
                if (Mask[i] == 'X')
                    continue;

                result[i] = Mask[i];
            }

            return number;
        }
    }
}