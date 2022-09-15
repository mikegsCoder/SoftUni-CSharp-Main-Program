using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BasicWebServer.Demo.Controllers;
using BasicWebServer.Server;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using static System.Collections.Specialized.BitVector32;

namespace BasicWebServer.Demo
{
    public class Startup
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
                .MapGet<HomeController>("/", c => c.Index())
                .MapGet<HomeController>("/Redirect", c => c.Redirect())
                .MapGet<HomeController>("/HTML", c => c.Html())
                .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
                .MapGet<HomeController>("/Content", c => c.Content())
                .MapPost<HomeController>("/Content", c => c.DownloadContent())
                .MapGet<HomeController>("/Cookies", c => c.Cookies())
                .MapGet<HomeController>("/Session", c => c.Session())
                .MapGet<UsersController>("/Login", c => c.Login())
                .MapPost<UsersController>("/Login", c => c.LogInUser()))
            .Start();
    }
}
