using NetCoreDI.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDI.IO
{
    public class MyConsoleWriter : IWriter
    {
        void IWriter.Write(string s)
        {
            Console.WriteLine("My " + s); ;
        }
    }
}
