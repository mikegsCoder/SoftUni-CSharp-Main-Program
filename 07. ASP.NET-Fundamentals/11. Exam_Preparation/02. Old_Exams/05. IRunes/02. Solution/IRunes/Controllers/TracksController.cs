using SUS.HTTP;
using SUS.MvcFramework;

namespace IRunes.Controllers
{
    public class TracksController : Controller
    {
        public HttpResponse Create(string albumId)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/");
            }

            var viewModel = tracksService.GetTrackViewModel(albumId);

            return View(viewModel);
        }
    }
}
