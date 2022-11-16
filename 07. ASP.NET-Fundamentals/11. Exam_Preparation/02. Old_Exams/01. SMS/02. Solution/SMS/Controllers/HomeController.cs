namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Services.ProductService;
    using SMS.Services.UserService;
    using SMS.ViewModels.ProductViewModels;

    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IProductService productService;

        public HomeController(
            IUserService _userService,
            IProductService _productService)
        {
            userService = _userService;
            productService = _productService;
        }

        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                string username = userService.GetUsername(User.Id);

                AllProductsViewModel model = new AllProductsViewModel()
                {
                    Username = username,
                    Products = productService.GetProducts()
                };

                return View(model, "/Home/IndexLoggedIn");
            }

            return this.View();
        }
    }
}