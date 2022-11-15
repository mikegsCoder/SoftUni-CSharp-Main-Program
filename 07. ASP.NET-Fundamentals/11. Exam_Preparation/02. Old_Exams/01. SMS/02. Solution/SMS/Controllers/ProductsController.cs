using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Services.ProductService;
using SMS.ViewModels;
using SMS.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService _productService)
        {
            productService = _productService;
        }

        [Authorize]
        public HttpResponse Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreateProductViewModel model)
        {
            var errors = productService.Create(model);

            if (errors.Any())
            {
                ErrorViewModel errorModel = new ErrorViewModel()
                {
                    ErrorMessage = String.Join(", ", errors)
                };

                return View(errorModel, "/Error");
            }

            return Redirect("/");
        }
    }
}
