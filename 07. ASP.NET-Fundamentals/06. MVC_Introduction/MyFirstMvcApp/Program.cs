using SUS.MvcFramework;

namespace MyFirstMvcApp
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup(), 80);
        }
    }
}