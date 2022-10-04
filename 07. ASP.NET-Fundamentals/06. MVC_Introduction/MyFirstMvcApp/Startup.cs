using SUS.HTTP;
using SUS.MvcFramework;
using MyFirstMvcApp.Controllers;
using System.Collections.Generic;
using SUS.HTTP.Enums;
using HttpMethod = SUS.HTTP.Enums.HttpMethod;

namespace MyFirstMvcApp
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {
            //throw new System.NotImplementedException();
        }

        public void Configure(List<Route> routeTable)
        {
            routeTable.Add(new Route("/", HttpMethod.Get, new HomeController().Index));

            routeTable.Add(new Route("/users/login", HttpMethod.Get, new UsersController().Login));
            routeTable.Add(new Route("/users/register", HttpMethod.Get, new UsersController().Register));
            routeTable.Add(new Route("/users/login", HttpMethod.Post, new UsersController().DoLogin));
        }
    }
}