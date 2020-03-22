using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLab4.Exceptions
{
    class InvalidEmailException : ArgumentException
    {
        public string Value { get; }
        public override string Message { get; }
        public InvalidEmailException(string val)
        {
            Value = val;
            Message = "Invalid email!";
        }
    }
}
