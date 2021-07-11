using P04WildFarm.Core;
using P04WildFarm.Interfaces;
using System;

namespace P04WildFarm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
