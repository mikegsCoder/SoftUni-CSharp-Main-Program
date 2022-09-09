using BasicWebServer.Server;

namespace BasicWebServer.Demo
{
    public class Startup
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
            Name: <input type='text' name='Name'/>
            Age: <input type='number' name ='Age'/>
            <input type='submit' value ='Save' />
        </form>";

        public static void Main()
        {
            var server = new HttpServer("127.0.0.1", 8080);
            server.Start();
        }
    }
}
