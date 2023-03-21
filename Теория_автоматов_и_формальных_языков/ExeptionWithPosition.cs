using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR__automats_
{
    internal class ExceptionWithPosition : Exception
    {
        public int Position;

        public ExceptionWithPosition(string message, int pos) : base(message)

        {
            Position = pos;
        }
    }
}
