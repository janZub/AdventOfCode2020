using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day5
{
    public class Seat
    {
        public virtual string Code { get; }
        public Seat(string code)
        {
            Code = code;
        }
        public virtual int GetSeatId()
        {
            return GetRowId() * 8 + GetColumnId();
        }
        public virtual int GetRowId()
        {
            var code = GetRowCode();
            var id = GetCodeId(code, 'B');

            return id;
        }
        public virtual int GetColumnId()
        {
            var code = GetColumnCode();
            var id = GetCodeId(code, 'R');

            return id;
        }

        private int GetCodeId(string code, char letter)
        {
            var id = 0;

            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == letter)
                    id += (int)Math.Pow(2, code.Length - 1 - i);

            }
            return id;
        }
        private string GetRowCode()
        {
            return Code.Substring(0, 7);
        }
        private string GetColumnCode()
        {
            return Code.Substring(7, 3);
        }
    }
}