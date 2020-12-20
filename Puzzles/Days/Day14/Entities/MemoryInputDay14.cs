using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day14
{
    public class MemoryInputDay14
    {
        public virtual ulong Number { get; set; }
        public virtual int Order { get; private set; }
        public virtual IMask Mask { get; private set; }
        public virtual int MemoryIndex { get; private set; }

        public MemoryInputDay14(ulong number, int memoryIndex, int order, IMask mask)
        {
            Number = number;
            MemoryIndex = memoryIndex;
            Mask = mask;
            Order = order;
        }
    }
}