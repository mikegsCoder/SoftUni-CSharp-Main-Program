using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor
{
	using System;
    using System.Linq;

    using Newtonsoft.Json;

    using Data;
    using VaporStore.DataProcessor.Dto.Export;
    using VaporStore.Data.Models.Enums;
    using System.Xml;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var result = context.Genres
                .Where(g => genreNames.Contains(g.Name))
                .ToArray()
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games.Where(gg => gg.Purchases.Any())
                    .ToArray()
                    .Select(gg => new
                    {
                        Id = gg.Id,
                        Title = gg.Name,
                        Developer = gg.Developer.Name,
                        Tags = string.Join(", ", gg.GameTags.Select(gt => gt.Tag.Name).ToArray()),
                        Players = gg.Purchases.Count
                    })
                    .OrderByDescending(x => x.Players)
                    .ToArray(),
                    TotalPlayers = g.Games.Sum(ga => ga.Purchases.Count)
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToArray();

            var json = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return json;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string purchaseType)
        {
            PurchaseType purchaseTypeEnum = Enum.Parse<PurchaseType>(purchaseType);

            var users = context.Users
                .Where(u => u.Cards.Any(c => c.Purchases.Any(p => p.Type == purchaseTypeEnum)))
                .ToArray()
                .Select(u => new ExportUserDto
                {
                    Username = u.Username,
                    Purchases = context.Purchases.Where(p => p.Card.User.Username == u.Username && p.Type == purchaseTypeEnum)
                    .ToArray()
                    .Select(p => new ExportUserPurchaseDto
                    {
                        CardNumber = p.Card.Number,
                        CardCvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new ExportUserPurchaseGameDto
                        {
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price,
                            Name = p.Game.Name
                        }
                    })
                    .OrderBy(p => p.Date)
                    .ToArray(),
                    TotalSpent = context.Purchases.Where(p => p.Card.User.Username == u.Username && p.Type == purchaseTypeEnum)
                    .ToArray()
                    .Sum(p => p.Game.Price)
                })                
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportUserDto[]), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            StringBuilder sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}