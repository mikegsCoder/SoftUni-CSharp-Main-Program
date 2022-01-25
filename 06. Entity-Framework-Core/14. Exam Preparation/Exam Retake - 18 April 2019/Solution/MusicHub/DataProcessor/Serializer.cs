namespace MusicHub.DataProcessor
{
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price.ToString("f2"),
                        Writer = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.Writer)
                    .ToList(),
                    AlbumPrice = a.Songs.Sum(s => s.Price).ToString("f2")
                })
                .ToList()
                .OrderByDescending(a => a.AlbumPrice)
                .ToList();

            string json = JsonConvert.SerializeObject(albums, Newtonsoft.Json.Formatting.Indented);
            return json;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context
                .Songs
                .Where(song => song.Duration.TotalSeconds > duration)
                .Select(song => new ExportSongDto
                {
                    SongName = song.Name,
                    WriterName = song.Writer.Name,
                    PerformerName = song.SongPerformers.Select(perf => perf.Performer.FirstName + " " + perf.Performer.LastName).FirstOrDefault(),
                    ProducerName = song.Album.Producer.Name,
                    Duration = song.Duration.ToString("c", CultureInfo.InvariantCulture)
                })
                .OrderBy(song => song.SongName)
                .ThenBy(song => song.WriterName)
                .ThenBy(song => song.WriterName)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportSongDto[]), new XmlRootAttribute("Songs"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            StringBuilder sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), songs, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}