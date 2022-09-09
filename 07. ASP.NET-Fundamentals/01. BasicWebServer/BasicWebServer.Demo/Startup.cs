using BasicWebServer.Server;
using BasicWebServer.Server.Responses;

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
         => new HttpServer(routes => routes
               .MapGet("/", new TextResponse("Hello from the server!"))
               .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
               .MapGet("/HTML", new HtmlResponse(Startup.HtmlForm))
           .Start();

    }
}
