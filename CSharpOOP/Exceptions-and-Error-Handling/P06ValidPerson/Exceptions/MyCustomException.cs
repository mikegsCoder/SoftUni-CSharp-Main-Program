using System;
using System.Collections.Generic;
using System.Text;

namespace P06ValidPerson.Exceptions
{
    public class MyCustomException : Exception
    {
        public MyCustomException(string msg)
            : base(msg)
        {

        }
    }
}
