using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day14
{
    public class NumberToCharConverterDay14
    {
        private static int defaultLength = 36;
        public static char[] ConvertNumberToCharArray(ulong number)
        {
            var charNumber = new char[defaultLength];
            for (int i = 0; i < defaultLength; i++)
            {
                var bitI = (ulong)Math.Pow(2, defaultLength - i - 1);
                if (number >= bitI)
                {
                    number -= bitI;
                    charNumber[i] = '1';
                }
                else
                    charNumber[i] = '0';
            }

            return charNumber;
        }
        public static ulong ConvertCharArrayToNumber(char[] numberChar)
        {
            ulong number = 0;
            for (int i = 0; i < numberChar.Length; i++)
            {
                if (numberChar[i] == '0')
                    continue;

                number += (ulong)Math.Pow(2, numberChar.Length - i - 1);
            }

            return number;
        }
        public static ulong ApplyMaskToNumber(ulong number, IMask mask)
        {
            var numberToString = ConvertNumberToCharArray(number);
            var numberAfterMask = mask.ApplyMask(numberToString);
            var numberUlong = ConvertCharArrayToNumber(numberAfterMask);

            return numberUlong;
        }
    }
}