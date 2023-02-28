using IRunes.Data;
using IRunes.Data.Models;
using IRunes.ViewModels.Tracks;
using System;
using System.Linq;

namespace IRunes.Services.Tracks
{
    public class TracksService : ITracksService
    {
        private readonly ApplicationDbContext db;

        public TracksService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public CreateTrackViewModel GetTrackViewModel(string albumId)
        {
            var viewModel = new CreateTrackViewModel
            {
                AlbumId = albumId
            };

            return viewModel;
        }

        public void CreateTrack(string albumId, CreateTrackInputModel inputModel)
        {
            var track = new Track
            {
                Name = inputModel.Name,
                Link = inputModel.Link,
                Price = inputModel.Price,
                AlbumId = albumId
            };

            db.Tracks.Add(track);
            db.SaveChanges();
        }
    }
}
