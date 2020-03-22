using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLab4.Exceptions
{
    class FutureBirthDateException : ArgumentOutOfRangeException
    {
        public DateTime Value{ get; }
        public override string Message { get; }
        public FutureBirthDateException(DateTime val)
        {
            Value = val;
            Message = "Your birth date can`t be in the future!";
        }
    }
}
