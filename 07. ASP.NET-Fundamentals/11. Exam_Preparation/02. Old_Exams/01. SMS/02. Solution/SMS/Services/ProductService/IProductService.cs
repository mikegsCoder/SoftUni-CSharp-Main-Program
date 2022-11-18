using SMS.ViewModels.ProductViewModels;
using System.Collections.Generic;

namespace SMS.Services.ProductService
{
    public interface IProductService
    {
        ICollection<string> Create(CreateProductViewModel model);

        IEnumerable<ProductViewModel> GetProducts();
    }
}
