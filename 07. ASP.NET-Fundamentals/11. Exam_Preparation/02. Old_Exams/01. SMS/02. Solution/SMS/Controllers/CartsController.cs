using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Services.CartService;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService cartService;

        public CartsController(ICartService _cartService) 
        {
            cartService = _cartService;
        }

        [Authorize]
        public HttpResponse AddProduct(string productId)
        {
            var products = cartService.AddProduct(productId, User.Id);

            return View(products, "/Carts/Details");
        }

        [Authorize]
        public HttpResponse Details(string productId)
        {
            var products = cartService.GetProducts(User.Id);

            return View(products);
        }

        [Authorize]
        public HttpResponse Buy()
        {
            cartService.BuyProducts(User.Id);

            return Redirect("/");
        }
    }
}
