using SillyGame.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SillyGame.IO
{
    public class MyConsoleWriter : IWriter
    {
        void IWriter.Write(string s)
        {
            Console.WriteLine("My " + s); ;
        }
    }
}
