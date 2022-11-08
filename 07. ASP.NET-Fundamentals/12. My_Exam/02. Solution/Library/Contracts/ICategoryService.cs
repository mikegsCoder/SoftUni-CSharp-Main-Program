using Library.Data.Models;

namespace Library.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
