namespace MusicHub.DataProcessor
{
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static object XMLConverter { get; private set; }

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            List<Writer> writers = JsonConvert.DeserializeObject<List<Writer>>(jsonString);

            List<Writer> validWriters = new List<Writer>();
            StringBuilder sb = new StringBuilder();

            foreach (var writer in writers)
            {
                if (!IsValid(writer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validWriters.Add(writer);
                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.AddRange(validWriters);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            List<ImportProducerDto> producers = JsonConvert.DeserializeObject<List<ImportProducerDto>>(jsonString);

            List<Producer> validProducers = new List<Producer>();
            StringBuilder sb = new StringBuilder();

            foreach (var producer in producers)
            {
                bool areAlbumsValid = producer.Albums.All(a => IsValid(a));
                bool areDatesValid = producer.Albums.All(x => DateTime.ParseExact(x.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None) != null);

                if (!IsValid(producer) || !areAlbumsValid || !areDatesValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Producer p = new Producer()
                {
                    Name = producer.Name,
                    Pseudonym = producer.Pseudonym,
                    PhoneNumber = producer.PhoneNumber,
                    Albums = producer.Albums.Select(a => new Album
                    {
                        Name = a.Name,
                        ReleaseDate = DateTime.ParseExact(a.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)
                    })
                    .ToList()
                };

                validProducers.Add(p);

                string msg = string.Empty;

                if (p.PhoneNumber != null)
                {
                    msg = string.Format(SuccessfullyImportedProducerWithNoPhone, p.Name, p.Albums.Count());
                }
                else
                {
                    msg = string.Format(SuccessfullyImportedProducerWithPhone, p.Name, p.PhoneNumber, p.Albums.Count());
                }

                sb.AppendLine(msg);
            }

            context.Producers.AddRange(validProducers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSongDto[]), new XmlRootAttribute("Songs"));
            ImportSongDto[] songs = (ImportSongDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            List<Song> validSongs = new List<Song>();

            foreach (var song in songs)
            {
                bool isGenreValid = Enum.TryParse<Genre>(song.Genre, out Genre genre);
                var album = context.Albums.FirstOrDefault(a => a.Id == song.AlbumId);
                var writer = context.Writers.FirstOrDefault(w => w.Id == song.WriterId);
                bool isDurationValid = TimeSpan.TryParseExact(song.Duration, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan duration);
                bool isDateValid = DateTime.TryParseExact(song.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime createdOn);

                if (!IsValid(song) || !isGenreValid || !isDurationValid || !isDateValid 
                    || album == null || writer == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Song s = new Song()
                {
                    Name = song.Name,
                    Duration = duration,
                    CreatedOn = createdOn,
                    Genre = genre,
                    AlbumId = album.Id,
                    WriterId = writer.Id,
                    Price = song.Price
                };

                validSongs.Add(s);
                sb.AppendLine(string.Format(SuccessfullyImportedSong, s.Name, s.Genre, s.Duration));
            }

            context.Songs.AddRange(validSongs);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPerformerDto[]), new XmlRootAttribute("Performers"));
            ImportPerformerDto[] performers = (ImportPerformerDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            List<Performer> validPerformers = new List<Performer>();

            foreach (var performer in performers)
            {
                bool areSongsValid = performer.PerformersSongs.All(ps => context.Songs.Any(s => s.Id == ps.SongId));

                if (!IsValid(performer) || !areSongsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Performer p = new Performer()
                {
                    FirstName = performer.FirstName,
                    LastName = performer.LastName,
                    Age = performer.Age,
                    NetWorth = performer.NetWorth,
                    PerformerSongs = performer.PerformersSongs.Select(ps => new SongPerformer
                    {
                        SongId = ps.SongId
                    })
                    .ToList()
                };

                validPerformers.Add(p);
                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, p.FirstName, p.PerformerSongs.Count));
            }

            context.Performers.AddRange(validPerformers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            ValidationContext context = new ValidationContext(entity);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, context, validationResults, true);
            return isValid;
        }
    }
}