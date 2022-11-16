using Microsoft.IdentityModel.Tokens;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Services.ValidationService;
using SMS.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.ProductService
{
    public class ProductService : IProductService
    {   
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public ProductService(
            IRepository _repo,
            IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            var products = repo.All<Product>()
                .Select(p => new ProductViewModel()
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2")
                })
                .ToList();

            return products;
        }

        public ICollection<string> Create(CreateProductViewModel model)
        {
            var errors = new List<string>();

            var validationErrors = validationService.ValidateModel(model);

            if (validationErrors.Any())
            {
                return validationErrors;
            }

            decimal price = 0;

            if (!decimal.TryParse(model.Price, NumberStyles.Float, CultureInfo.InvariantCulture, out price)
                || price < 0.05M || price > 1000M)
            {
                errors.Add("Price must be between 0.05 and 1000");

                return errors;
            }

            var product = new Product()
            {
                Name = model.Name,
                Price = price
            };

            try
            {
                repo.Add(product);
                repo.SaveChanges();
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }

            return errors;
        }
    }
}
