using SUS.HTTP;
using SUS.MvcFramework;


namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        public HttpResponse Add(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var viewModel = new IssueAddViewModel
            {
                CarId = carId
            };

            return this.View(viewModel);
        }
    }
}
