using IRunes.Services.Albums;
using IRunes.ViewModels.Albums;
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

        public HttpResponse Create()
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Create(AlbumCreateInputModel inputModel)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/");
            }

            if (string.IsNullOrEmpty(inputModel.Name)
               || inputModel.Name.Length < 4
               || inputModel.Name.Length > 20)
            {
                return Redirect("/Albums/Create");
            }

            if (string.IsNullOrEmpty(inputModel.Cover))
            {
                return Redirect("/Albums/Create");
            }

            albumsService.CreateAlbum(inputModel);

            return Redirect("/Albums/All");
        }
    }
}
