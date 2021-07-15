using System;
using ShoppingSpree.Core;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
