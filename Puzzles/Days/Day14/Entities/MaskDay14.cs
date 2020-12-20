using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day14
{
    public class MaskDay14 : IMask
    {
        public char[] Mask { get; protected set; }

        public MaskDay14(string mask)
        {
            Mask = mask.ToCharArray();
        }
        public char[] ApplyMask(char[] number)
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