using SMS.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.ProductService
{
    public interface IProductService
    {
        ICollection<string> Create(CreateProductViewModel model);

        IEnumerable<ProductViewModel> GetProducts();
    }
}
