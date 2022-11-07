using Library.Models.Book;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetAllAsync();

        Task<IEnumerable<BookViewModel>> GetMineAsync(string userId);
    }
}
