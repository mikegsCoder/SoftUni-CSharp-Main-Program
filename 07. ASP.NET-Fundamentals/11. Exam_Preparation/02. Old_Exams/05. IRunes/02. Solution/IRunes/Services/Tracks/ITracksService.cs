using IRunes.ViewModels.Tracks;

namespace IRunes.Services.Tracks
{
    public interface ITracksService
    {
        CreateTrackViewModel GetTrackViewModel(string albumId);
    }
}
