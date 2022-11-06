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
       
        [HttpGet]
        public async Task<IActionResult> All()
        {
            return View();
        }
    }
}
