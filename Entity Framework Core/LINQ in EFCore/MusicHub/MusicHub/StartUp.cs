namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using System.Globalization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            // DbInitializer.ResetDatabase(context);

            // Console.WriteLine(ExportAlbumsInfo(context, 9));
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
            //Test your solutions here


        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                 .Where(x => x.ProducerId == producerId)
                 .Select(x => new
                 {
                     AlbumPrice = x.Price,
                     AlbumName = x.Name,
                     ReleaseDate = x.ReleaseDate,  //TODO,
                     ProducerName = x.Producer.Name,
                     Songs = x.Songs.Select(s => new
                     {
                         SongName = s.Name,
                         SongPrice = s.Price,
                         WriterName = s.Writer.Name,
                     })
                                .OrderByDescending(s => s.SongName)
                                .ThenBy(s => s.WriterName)
                                .ToList()
                 })
                 .ToList()
                 .OrderByDescending(x => x.AlbumPrice);

            StringBuilder sb = new StringBuilder();

            foreach (var a in albums)
            {
                sb.AppendLine($"-AlbumName: {a.AlbumName}")
                    .AppendLine($"-ReleaseDate: {a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}")
                    .AppendLine($"-ProducerName: {a.ProducerName}")
                    .AppendLine($"-Songs:");
                var count = 1;
                foreach (var s in a.Songs)
                {
                    sb.AppendLine($"---#{count}")
                        .AppendLine($"---SongName: {s.SongName}")
                        .AppendLine($"---Price: {s.SongPrice:f2}")
                        .AppendLine($"---Writer: {s.WriterName}");

                    count++;
                }
                sb.AppendLine($"-AlbumPrice: {a.AlbumPrice:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var durationInTimeSpan = TimeSpan.FromSeconds(duration);

            var songs = context.Songs
                .Where(s => s.Duration > durationInTimeSpan)
                .Select(s => new
                {
                    SongName = s.Name,
                    PerformerFullName = s.SongPerformers
                                .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                                .FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PerformerFullName)
                .ToList();


            StringBuilder sb = new StringBuilder();
            var count = 1;
            foreach (var s in songs)
            {

                sb.AppendLine($"-Song #{count}")
                   .AppendLine($"---SongName: {s.SongName}")
                   .AppendLine($"---Writer: {s.WriterName}")
                   .AppendLine($"---Performer: {s.PerformerFullName}")
                   .AppendLine($"---AlbumProducer: {s.AlbumProducer}")
                  .AppendLine($"---Duration: {s.Duration:c}");
                count++;
            }


            return sb.ToString().TrimEnd();
        }
    }
}
