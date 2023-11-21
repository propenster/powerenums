using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerEnums.Test
{
    internal class MyCustomException : Exception
    {
        public MyCustomException(string message) : base(message)
        {
            
        }
    }
}
