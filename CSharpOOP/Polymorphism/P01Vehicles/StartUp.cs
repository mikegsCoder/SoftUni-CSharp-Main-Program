using P01Vehicles.Core;
using P01Vehicles.Interfaces;
using System;

namespace P01Vehicles
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
