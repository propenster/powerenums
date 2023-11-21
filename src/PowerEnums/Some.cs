using System;
using System.Collections.Generic;
using System.Text;

namespace PowerEnums
{
    public class Some<T> : Option<T>
    {
        public Some(Some<T> some) : base(some)
        {
            _IsNone = false;
        }
        public Some(T val) : base(val)
        {
            _IsNone = false;
        }


    }
}
