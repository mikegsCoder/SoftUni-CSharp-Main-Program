using IRunes.Services.Albums;
using SUS.HTTP;
using SUS.MvcFramework;

namespace IRunes.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;

        public AlbumsController(IAlbumsService _albumsService)
        {
            albumsService = _albumsService;
        }

        public HttpResponse All()
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/");
            }

            var viewModel = albumsService.GetAllAlbums();

            return View(viewModel);
        }
    }
}
