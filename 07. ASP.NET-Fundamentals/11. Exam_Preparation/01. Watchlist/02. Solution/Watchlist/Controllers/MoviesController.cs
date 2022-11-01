using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watchlist.Contracts;
using Watchlist.Models;

namespace Watchlist.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService _movieService)
        {
            movieService = _movieService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await movieService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                var model = await movieService.GetWatchedAsync(userId);

                return View("Mine", model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddMovieViewModel()
            {
                Genres = await movieService.GetGenresAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Add));
            }

            try
            {
                await movieService.AddMovieAsync(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Add));
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await movieService.AddToCollectionAsync(movieId, userId);
            }
            catch (Exception)
            {
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await movieService.RemoveFromCollectionAsync(movieId, userId);
            }
            catch (Exception)
            {
            }

            return RedirectToAction(nameof(Watched));
        }
    }
}
