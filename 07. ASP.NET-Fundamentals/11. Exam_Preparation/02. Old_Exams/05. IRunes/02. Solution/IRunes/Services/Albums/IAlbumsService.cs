using IRunes.ViewModels.Albums;

namespace IRunes.Services.Albums
{
    public interface IAlbumsService
    {
        AllAlbumsViewModel GetAllAlbums();

        void CreateAlbum(AlbumCreateInputModel inputModel);

        AlbumDetailsViewModel GetAlbumDetails(string albumId);
    }
}
