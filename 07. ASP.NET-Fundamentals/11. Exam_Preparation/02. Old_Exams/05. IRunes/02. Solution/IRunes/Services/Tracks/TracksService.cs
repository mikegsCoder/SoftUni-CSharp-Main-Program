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
    }
}
