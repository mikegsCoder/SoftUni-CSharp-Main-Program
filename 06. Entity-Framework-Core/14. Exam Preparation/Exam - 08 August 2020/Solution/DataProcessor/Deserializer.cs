namespace VaporStore.DataProcessor
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using VaporStore.DataProcessor.Dto.Import;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var games = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            List<Game> validGames = new List<Game>();

            foreach (var game in games)
            {
                bool areTagsValid = game.Tags.All(t => IsValid(t)) && game.Tags.All(t => !string.IsNullOrWhiteSpace(t)) && game.Tags.Length > 0;
                bool isDateValid = DateTime.TryParseExact(game.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

                if (!IsValid(game) || !areTagsValid || !isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Game g = new Game()
                {
                    Name = game.Name,
                    Price = game.Price,
                    ReleaseDate = releaseDate
                };

                Developer developer = context.Developers.FirstOrDefault(d => d.Name == game.Developer);

                if (developer == null)
                {
                    developer = new Developer() { Name = game.Developer };
                    context.Developers.Add(developer);
                    context.SaveChanges();
                }

                g.Developer = developer;

                Genre genre = context.Genres.FirstOrDefault(g => g.Name == game.Genre);

                if (genre == null)
                {
                    genre = new Genre() { Name = game.Genre };
                    context.Genres.Add(genre);
                    context.SaveChanges();
                }

                g.Genre = genre;

                foreach (string tagstr in game.Tags)
                {
                    Tag tag = context.Tags.FirstOrDefault(t => t.Name == tagstr);

                    if (tag == null)
                    {
                        tag = new Tag() { Name = tagstr };
                        context.Tags.Add(tag);
                        context.SaveChanges();
                    }

                    g.GameTags.Add(new GameTag() { Game = g, Tag = tag });
                }

                validGames.Add(g);
                sb.AppendLine(string.Format(SuccessfullyImportedGame, g.Name, g.Genre.Name, g.GameTags.Count));
            }

            context.Games.AddRange(validGames);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var users = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);
            var sb = new StringBuilder();
            List<User> validUsers = new List<User>();

            foreach (ImportUserDto user in users)
            {
                bool areCardValid = user.Cards.All(c => IsValid(c)) && user.Cards.Length > 0 && user.Cards.All(c => Enum.TryParse<CardType>(c.Type, out CardType type));

                if (!IsValid(user) || !areCardValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User u = new User()
                {
                    FullName = user.FullName,
                    Username = user.Username,
                    Email = user.Email,
                    Age = user.Age
                };

                foreach (var cardDto in user.Cards)
                {
                    Card card = new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = Enum.Parse<CardType>(cardDto.Type)
                    };

                    u.Cards.Add(card);
                }

                validUsers.Add(u);
                sb.AppendLine(string.Format(SuccessfullyImportedUser, u.Username, u.Cards.Count));
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));

            using StringReader stringReader = new StringReader(xmlString);

            ImportPurchaseDto[] purchases = (ImportPurchaseDto[])xmlSerializer.Deserialize(stringReader);

            List<Purchase> validPurchases = new List<Purchase>();

            foreach (ImportPurchaseDto purchase in purchases)
            {
                bool isTypeValid = Enum.TryParse<PurchaseType>(purchase.PurchaseType, out PurchaseType type);
                bool isDateValid = DateTime.TryParseExact(purchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime purchaseDate);
                bool isCardValid = context.Cards.Any(c => c.Number == purchase.CardNumber);
                bool isGameValid = context.Games.Any(g => g.Name == purchase.GameTitle);

                if (!IsValid(purchase) || !isTypeValid || !isDateValid || !isCardValid || !isGameValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase p = new Purchase()
                {
                    Type = type,
                    ProductKey = purchase.Key,
                    Date = purchaseDate,
                    Card = context.Cards.FirstOrDefault(c => c.Number == purchase.CardNumber),
                    Game = context.Games.FirstOrDefault(g => g.Name == purchase.GameTitle)
                };
                
                validPurchases.Add(p);
                sb.AppendLine(string.Format(SuccessfullyImportedPurchase, purchase.GameTitle, p.Card.User.Username));
            }

            context.Purchases.AddRange(validPurchases);
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