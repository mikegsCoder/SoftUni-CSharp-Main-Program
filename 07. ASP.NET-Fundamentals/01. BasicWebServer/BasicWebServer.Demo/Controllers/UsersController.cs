using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Controllers;

namespace BasicWebServer.Demo.Controllers
{
    public class UsersController : Controller
    {
        private const string LoginForm = @"<form action='/Login' method='POST'>
                Username: <input type='text' name='Username'/>
                Password: <input type='text' name='Password'/>
                <input type='submit' value ='Log In' /> 
            </form>";

        public UsersController(Request request) 
            : base(request)
        {
        }

        public Response Login() => Html(UsersController.LoginForm);
    }
}
