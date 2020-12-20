using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day13
{

    //a*ni + b*Ni = 1
    public class EuclidForCoPrimeDay13
    {
        public static ulong GetCofficentBForNi(ulong ni, ulong Ni)
        {
            long a0 = 1, a1 = 0;
            long b0 = 0, b1 = 1;
            long holderGlobalni = (long)ni;

            while (ni > 0)
            {
                ulong q = Ni / ni;
                var holderNi = Ni;
                Ni = ni;
                ni = holderNi % ni;

                var holdera0 = a0;
                a0 = a1;
                a1 = holdera0 - (long)q * a1;

                var holderb0 = b0;
                b0 = b1;
                b1 = holderb0 - (long)q * b1;
            }

            if (a0 < 0)
                return (ulong)(holderGlobalni + a0);

            return (ulong)a0;
        }
    }
}