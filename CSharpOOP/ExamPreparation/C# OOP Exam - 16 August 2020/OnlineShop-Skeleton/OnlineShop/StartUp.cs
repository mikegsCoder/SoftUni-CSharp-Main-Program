﻿using System.IO;
using OnlineShop.Core;
using OnlineShop.IO;

namespace OnlineShop
{
    public class StartUp
    {
        public static void Main()
        {
            // Clears output.txt file
            string pathFile = Path.Combine("..", "..", "..", "output.txt");
            File.Create(pathFile).Close();

            IReader reader = new ConsoleReader();
            //IWriter writer = new ConsoleWriter();
            IWriter writer = new FileWriter(pathFile);
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            //IController controller = null; //new Controller();
            IController controller = new Controller();

            IEngine engine = new Engine(reader, writer, commandInterpreter, controller);
            engine.Run();
        }
    }
}
