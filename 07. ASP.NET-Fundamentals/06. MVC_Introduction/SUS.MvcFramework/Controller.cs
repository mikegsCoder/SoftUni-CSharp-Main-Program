using SUS.HTTP;
using System.Text;
using SUS.HTTP.Enums;
using System.Runtime.CompilerServices;

namespace SUS.MvcFramework
{
    public abstract class Controller
    {
        public HttpResponse View([CallerMemberName] string viewPath = null)
        {
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");

            var viewContent = System.IO.File.ReadAllText($"Views/{this.GetType().Name.Replace("Controller", string.Empty)}/{viewPath}.cshtml");

            var responseHtml = layout.Replace("@RenderBody()", viewContent);

            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

       
    }
}