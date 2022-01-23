using System;
using Newtonsoft.Json;

using Instagraph.Data;
using System.Linq;
using System.Xml.Linq;
using Instagraph.DataProcessor.Dtos.Export;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.IO;

namespace Instagraph.DataProcessor
{
    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var result = context.Posts
                .Where(p => !p.Comments.Any())
                .Select(p => new
                {
                    Id = p.Id,
                    Picture = p.Picture.Path,
                    User = p.User.Username
                })
                .OrderBy(p => p.Id)
                .ToList();

            var json = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return json;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var result = context.Users
                .Where(u => u.Posts.Any(p => p.Comments.Any(c => u.Followers.Select(uf => uf.FollowerId).Contains(c.UserId))))
                .OrderByDescending(u => u.Id)
                .Select(u => new
                {
                    Username = u.Username,
                    Followers = u.Followers.Count
                })
                .ToList();

            var json = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return json;
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var result = context.Users
                .Select(u => new UserDto()
                {
                    Username = u.Username,
                    MostComments = u.Posts.Count > 0 ?
                    u.Posts.OrderByDescending(p => p.Comments.Count)
                    .First()
                    .Comments
                    .Count : 0
                })
                .OrderByDescending(u => u.MostComments)
                .ThenBy(u => u.Username)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("users"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            StringBuilder sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), result, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
