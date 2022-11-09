using Library.Models.Book;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetAllAsync();

        Task<IEnumerable<BookViewModel>> GetMineAsync(string userId);

        Task AddBookAsync(AddBookViewModel model);

        Task AddToCollectionAsync(int bookId, string userId);

        Task RemoveFromCollectionAsync(int bookId, string userId);
    }
}
