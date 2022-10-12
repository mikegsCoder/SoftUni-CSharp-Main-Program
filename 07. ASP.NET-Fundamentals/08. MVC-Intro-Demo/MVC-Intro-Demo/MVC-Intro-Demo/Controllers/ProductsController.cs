using Microsoft.AspNetCore.Mvc;
using MVC_Intro_Demo.ViewModels;

namespace MVC_Intro_Demo.Controllers
{
    public class ProductsController : Controller
    {
        private IEnumerable<ProductViewModel> products = new List<ProductViewModel>
        {
            new ProductViewModel()
            {
                Id = 1,
                Name = "Cheese",
                Price = 7.00
            },

            new ProductViewModel()
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50
            },

            new ProductViewModel()
            {
                Id = 3,
                Name = "Bread",
                Price = 1.50
            }
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All(string keyword)
        {
            if (keyword != null)
            {
                IEnumerable<ProductViewModel> selectedproducts = products
                        .Where(p => p.Name.ToLower().Contains(keyword.ToLower()))
                        .ToArray();
                return this.View(selectedproducts);
            }

            return this.View(products);
        }
    }
}
