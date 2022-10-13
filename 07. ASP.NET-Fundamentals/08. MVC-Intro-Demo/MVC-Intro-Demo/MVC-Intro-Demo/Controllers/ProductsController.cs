using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVC_Intro_Demo.ViewModels;
using System.Text;
using System.Text.Json;

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

        [ActionName("My-Products")]
        public IActionResult SelectProducts(string keyword)
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

        public IActionResult AllAsJson()
        {
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            return this.Json(products, jsonOptions);
        }

        public IActionResult AllAsText()
        {
            string textResult = GetAllProductInfoAsString();

            return Content(textResult.ToString());
        }

        private string GetAllProductInfoAsString()
        {
            StringBuilder textResult = new StringBuilder();

            foreach (var product in products)
            {
                textResult.Append($"product {product.Id}: {product.Name} - {product.Price} lv")
                          .Append(Environment.NewLine);
            }

            return textResult.ToString().TrimEnd();
        }
    }
}
