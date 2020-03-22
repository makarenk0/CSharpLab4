using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLab4.Exceptions
{
    class OldBirthDateException : ArgumentOutOfRangeException
    {
        public DateTime Value { get; }
        public override string Message { get; }
        public OldBirthDateException(DateTime val)
        {
            Value = val;
            Message = "Your birth date can`t be so old!";
        }
    }
}
