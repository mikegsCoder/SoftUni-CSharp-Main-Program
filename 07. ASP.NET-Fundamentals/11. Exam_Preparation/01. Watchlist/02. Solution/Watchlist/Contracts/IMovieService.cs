using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieViewModel>> GetAllAsync();

        Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId);

        Task<IEnumerable<Genre>> GetGenresAsync();
    }
}
