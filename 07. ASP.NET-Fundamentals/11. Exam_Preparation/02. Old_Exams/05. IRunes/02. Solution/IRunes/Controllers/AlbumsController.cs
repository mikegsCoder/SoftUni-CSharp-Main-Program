using SUS.HTTP;
using SUS.MvcFramework;

namespace IRunes.Controllers
{
    public class AlbumsController : Controller
    {
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
