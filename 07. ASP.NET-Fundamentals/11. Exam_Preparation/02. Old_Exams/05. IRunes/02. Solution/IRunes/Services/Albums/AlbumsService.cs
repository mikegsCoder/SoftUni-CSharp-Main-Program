using IRunes.Data;
using IRunes.ViewModels.Albums;
using System.Linq;

namespace IRunes.Services.Albums
{
    public class AlbumsService : IAlbumsService
    {
        private readonly ApplicationDbContext db;

        public AlbumsService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public AllAlbumsViewModel GetAllAlbums()
        {
            var viewModel = new AllAlbumsViewModel
            {
                Albums = db.Albums
                    .Select(x => new AlbumViewModel
                    {
                        Name = x.Name,
                        Id = x.Id
                    }).ToList()
            };

            return viewModel;
        }
    }
}
