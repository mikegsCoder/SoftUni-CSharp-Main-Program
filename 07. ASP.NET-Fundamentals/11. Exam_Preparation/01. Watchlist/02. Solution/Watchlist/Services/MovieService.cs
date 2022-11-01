using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<MovieViewModel>> GetAllAsync()
        {
            return  await context.Movies
                .Include(m => m.Genre)
                .Select(m => new MovieViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Genre = m.Genre.Name,
                    Rating = m.Rating.ToString("F2")
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(um => um.Movie)
                .ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id");
            }

            return user.UsersMovies
                .Select(x => new MovieViewModel()
                {
                    Title = x.Movie.Title,
                    Director = x.Movie.Director,
                    ImageUrl = x.Movie.ImageUrl,
                    Rating = x.Movie.Rating.ToString("F2"),
                    Genre = x.Movie.Genre.Name,
                    Id = x.Movie.Id,
                })
                .ToList();
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task AddMovieAsync(AddMovieViewModel model)
        {
            decimal rating;

            if (!decimal.TryParse(model.Rating, NumberStyles.Float, CultureInfo.InvariantCulture, out rating)
                || rating < 0.00M || rating > 10.00M)
            {
                throw new InvalidDataException("Invalid rating.");
            }

            var movie = new Movie()
            {
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = rating,
                GenreId = model.GenreId,
            };

            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();
        }
    }
}
