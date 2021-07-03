using Microsoft.Extensions.DependencyInjection;
using NetCoreDI.IO;
using NetCoreDI.IO.Contracts;

namespace NetCoreDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IReader, ConsoleReader>()
                .AddSingleton<IWriter, MyConsoleWriter>()
                .AddSingleton<Engine, Engine>()
                .BuildServiceProvider();

            Engine engine = serviceProvider.GetService<Engine>();
            engine.Start();
        }
    }
}
