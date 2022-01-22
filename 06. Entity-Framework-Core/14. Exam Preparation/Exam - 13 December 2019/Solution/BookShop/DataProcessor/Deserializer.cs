namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";
        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportBookDto[]), new XmlRootAttribute("Books"));
            ImportBookDto[] books = (ImportBookDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            List<Book> validBooks = new List<Book>();

            foreach (var book in books)
            {
                bool isGenreValid = book.Genre > 0 && book.Genre < 4;                
                bool isDateValid = DateTime.TryParseExact(book.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime publishedOn);

                if (!IsValid(book) || !isGenreValid || !isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Book b = new Book()
                {
                    Name = book.Name,
                    Genre = (Genre)book.Genre,
                    Price = book.Price,
                    PublishedOn = publishedOn
                };

                validBooks.Add(b);
                sb.AppendLine(string.Format(SuccessfullyImportedBook, b.Name, b.Price));
            }

            context.Books.AddRange(validBooks);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            List<ImportAuthorDto> authors = JsonConvert.DeserializeObject<List<ImportAuthorDto>>(jsonString);
            List<Author> validAuthors = new List<Author>();
            StringBuilder sb = new StringBuilder();
                       
            foreach (var author in authors)
            {
                bool emailExists = validAuthors.Any(x => x.Email == author.Email);
                bool bookAreZero = author.Books.Length == 0;

                if (!IsValid(author) || emailExists || bookAreZero)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author a = new Author()
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Phone = author.Phone,
                    Email = author.Email
                };

                foreach (var book in author.Books)
                {
                    Book b = context.Books.FirstOrDefault(x => x.Id == book.BookId);
                    
                    if (b == null)
                    {
                        continue;
                    }

                    a.AuthorsBooks.Add(new AuthorBook() { Author = a, Book = b});
                }

                if (a.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validAuthors.Add(a);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, a.FirstName + " " + a.LastName, a.AuthorsBooks.Count));
            }

            context.Authors.AddRange(validAuthors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}