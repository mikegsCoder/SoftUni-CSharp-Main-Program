using Library.Contracts;
using Library.Models.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly ICategoryService categoryService;

        public BooksController(
            IBookService _bookService,
            ICategoryService _categoryService)
        {
            bookService = _bookService;
            categoryService = _categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await bookService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                var model = await bookService.GetMineAsync(userId);

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddBookViewModel()
            {
                Categories = await categoryService.GetCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Add));
            }

            try
            {
                await bookService.AddBookAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return RedirectToAction(nameof(Add));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await bookService.AddToCollectionAsync(bookId, userId);
            }
            catch (Exception)
            {
            }

            return RedirectToAction(nameof(All));
        }
    }
}
