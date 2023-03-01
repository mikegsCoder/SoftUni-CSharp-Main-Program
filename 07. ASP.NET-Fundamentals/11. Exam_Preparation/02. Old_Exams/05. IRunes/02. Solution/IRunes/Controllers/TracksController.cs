using IRunes.Services.Tracks;
using IRunes.ViewModels.Tracks;
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

        [HttpPost]
        public HttpResponse Create(string albumId, CreateTrackInputModel inputModel)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/");
            }

            if (string.IsNullOrEmpty(inputModel.Name)
               || inputModel.Name.Length < 4
               || inputModel.Name.Length > 20)
            {
                return Redirect($"/Tracks/Create?albumId={albumId}");
            }

            if (string.IsNullOrEmpty(inputModel.Link))
            {
                return Redirect($"/Tracks/Create?albumId={albumId}");
            }

            if (inputModel.Price < 0)
            {
                return Redirect($"/Tracks/Create?albumId={albumId}");
            }

            tracksService.CreateTrack(albumId, inputModel);

            return Redirect($"/Albums/Details?id={albumId}");
        }

        public HttpResponse Details(string albumId, string trackId)
        {
            if (!IsUserSignedIn())
            {
                Redirect("/");
            }

            var viewModel = tracksService.GetTrackDetails(albumId, trackId);

            return View(viewModel);
        }
    }
}
