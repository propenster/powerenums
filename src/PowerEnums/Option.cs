using System;
using System.Collections.Generic;
using System.Text;

namespace PowerEnums
{
    public class Option<T> : IOption
    {
        public bool _IsNone { get; set; }

        public T Value { get; set; }

        public Option(Some<T> some)
        {
            Value = some.Value;
            _IsNone = false;
        }
        public Option(T val)
        {
            Value = val;
        }
        public Option( )
        {
            Value = default(T);
            _IsNone = true;
        }

        public T ValueOrDefault()
        {
            return Value;
        }
        public T ValueOrError(string message)
        {
            if(Value == null || _IsNone)
            {
                throw new Exception(message);
            }
            return Value; 
        }
        public T ValueOrError(Action errorCallback)
        {
            if (Value == null || _IsNone)
            {
                errorCallback();
            }
            return Value;
        }

        public bool IsNone() => _IsNone == true;
        public bool IsSome() => _IsNone == false;
        
    }
    public interface IOption
    {
        bool _IsNone { get; set; }
        bool IsNone();
        bool IsSome();
    }
    
}
