using IRunes.Services.Tracks;
using SUS.HTTP;
using SUS.MvcFramework;

namespace IRunes.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;

        public TracksController(ITracksService _tracksService)
        {
            tracksService = _tracksService;
        }

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
