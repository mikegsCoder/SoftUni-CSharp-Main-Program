using IRunes.Data;
using IRunes.Data.Models;
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

        public void CreateAlbum(AlbumCreateInputModel inputModel)
        {
            var album = new Album
            {
                Cover = inputModel.Cover,
                Name = inputModel.Name
            };

            db.Albums.Add(album);

            db.SaveChanges();
        }

        public AlbumDetailsViewModel GetAlbumDetails(string albumId)
        {
            var tracks = db.Tracks
                .Where(x => x.AlbumId == albumId)
                .ToList();

            var viewModel = db.Albums
                .Select(x => new AlbumDetailsViewModel
                {
                    Name = x.Name,
                    Cover = x.Cover,
                    Id = x.Id,
                    Price = (x.Tracks.Sum(x => x.Price) * 0.87m).ToString("f2"),
                    Tracks = tracks
                }).FirstOrDefault();

            return viewModel;
        }
    }
}
