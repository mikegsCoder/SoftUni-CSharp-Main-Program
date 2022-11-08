using Library.Contracts;
using Library.Data.Models;
using Library.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly LibraryDbContext context;

        public CategoryService(LibraryDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
            => await context.Categories.ToListAsync();
    }
}
