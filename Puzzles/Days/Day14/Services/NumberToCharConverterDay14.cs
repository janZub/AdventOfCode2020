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
        public static char[] ApplyMaskToNumber(ulong number, IMask mask)
        {
            var numberToString = ConvertNumberToCharArray(number);
            var numberAfterMask = mask.ApplyMask(numberToString);

            return numberAfterMask;
        }

        //not elegant
        public static List<ulong> CreateNumbersFromInstableAddress(char[] unstableAdress)
        {
            var list = new List<ulong>();
            bool hasX = false;

            for (int i = 0; i < unstableAdress.Length; i++)
            {
                if (unstableAdress[i] == 'X')
                {
                    hasX = true;

                    var possibilty1 = (char[])unstableAdress.Clone();
                    var possibilty2 = (char[])unstableAdress.Clone();

                    possibilty1[i] = '0';
                    list.AddRange(CreateNumbersFromInstableAddress(possibilty1));

                    possibilty2[i] = '1';
                    list.AddRange(CreateNumbersFromInstableAddress(possibilty2));

                    break;
                }
            }

            if (!hasX)
                list.Add(ConvertCharArrayToNumber(unstableAdress));

            return list;
        }
    }
}