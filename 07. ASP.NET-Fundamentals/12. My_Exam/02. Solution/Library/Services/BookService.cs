﻿using Library.Contracts;
using Library.Data.Models;
using Library.Data;
using Library.Models.Book;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            return await context.Books
                .Include(b => b.Category)
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating.ToString("F2"),
                    Category = b.Category.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<BookViewModel>> GetMineAsync(string userId)
        {
            var user = await context.ApplicationUsers
               .Where(u => u.Id == userId)
               .Include(u => u.ApplicationUsersBooks)
               .ThenInclude(ub => ub.Book)
               .ThenInclude(b => b.Category)
               .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id is provided.");
            }

            return user.ApplicationUsersBooks
                .Select(x => new BookViewModel()
                {
                    Id = x.BookId,
                    Title = x.Book.Title,
                    Author = x.Book.Author,
                    ImageUrl = x.Book.ImageUrl,
                    Description = x.Book.Description,
                    Rating = x.Book.Rating.ToString("F2"),
                    Category = x.Book.Category.Name
                })
                .ToList();
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            decimal rating = 0;

            if (!decimal.TryParse(model.Rating, NumberStyles.Float, CultureInfo.InvariantCulture, out rating)
                || rating < 0.00M || rating > 10.00M)
            {
                throw new InvalidDataException("Invalid rating provided.");
            }

            var book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Rating = rating,
                CategoryId = model.CategoryId
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task AddToCollectionAsync(int bookId, string userId)
        {
            var user = await context.ApplicationUsers
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            var book = await context.Books
                .FirstOrDefaultAsync(m => m.Id == bookId);

            if (user == null || book == null)
            {
                throw new ArgumentNullException("User or movie does not exist.");
            }

            if (user.ApplicationUsersBooks.Any(x => x.BookId == bookId))
            {
                return;
            }

            user.ApplicationUsersBooks.Add(new ApplicationUserBook()
            {
                ApplicationUserId = userId,
                BookId = bookId,
            });

            await context.SaveChangesAsync();
        }

        public async Task RemoveFromCollectionAsync(int bookId, string userId)
        {
            var user = await context.ApplicationUsers
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentNullException("User does not exist.");
            }

            var toRemove = user.ApplicationUsersBooks
                .FirstOrDefault(ub => ub.BookId == bookId);

            if (toRemove == null)
            {
                return;
            }

            user.ApplicationUsersBooks.Remove(toRemove);

            await context.SaveChangesAsync();
        }
    }
}
