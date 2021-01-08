using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day25
{
    public class Cipher
    {
        private static ulong secretModNumber = 20201227;
        private static ulong secretNumber = 7;
        public ulong FindLoopSize(ulong publicKey)
        {
            ulong doorLoopSize = 0;
            ulong value = 1;

            //it should be safe if numbers are co-prime
            while (true)
            {
                ++doorLoopSize;
                value *= secretNumber;
                value %= secretModNumber;

                if (value == publicKey)
                    return doorLoopSize;
            }
        }
        public ulong TransformNumber(ulong value, ulong loopSize)
        {
            ulong encryption = 1;
            for (ulong i = 0; i < loopSize; i++)
            {
                encryption *= value;
                encryption %= secretModNumber;
            }
            return encryption;
        }
    }
}