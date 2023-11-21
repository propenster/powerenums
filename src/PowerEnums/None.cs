using System;
using System.Collections.Generic;
using System.Text;

namespace PowerEnums
{
    public class None<T> : Option<T>
    {
        public None()
        {
            _IsNone = true;
            Value = default(T);
        }
    }

}
