using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day14
{
    public class MaskDay14b : MaskDay14
    {
        public MaskDay14b(string mask) : base(mask) { }
        public override char[] ApplyMask(char[] number)
        {
            if (number.Length < 36)
                throw new Exception();

            var result = number;

            for (int i = 0; i < Mask.Length; i++)
            {
                if (Mask[i] == '0')
                    continue;

                result[i] = Mask[i];
            }

            return number;
        }
    }
}