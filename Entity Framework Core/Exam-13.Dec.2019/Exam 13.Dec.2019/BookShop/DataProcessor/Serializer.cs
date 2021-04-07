namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {


            var authors = context.Authors

                .Select(b => new ExportCraziestAuthorsDto()
                {
                    AuthorName = b.FirstName + " " + b.LastName,
                    Books = b.AuthorsBooks
                                   .Select(ab => ab.Book)
                                   .OrderByDescending(x => x.Price)
                                   .Select(x => new CraziestBooksDto()
                                   {
                                       BookName = x.Name,
                                       BookPrice = x.Price.ToString("0.00")
                                   })
                                    .ToArray()
                })
                 .ToArray()
                .OrderByDescending(b => b.Books.Length)
                .ThenBy(b => b.AuthorName)
                .ToArray();

            var result = JsonConvert.SerializeObject(authors, Formatting.Indented);

            return result;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ExportOldesBooksDto[]), new XmlRootAttribute("Books"));

            Enum.TryParse(typeof(Genre), "Science", out var genre);

            var books = context.Books
                .Where(x => x.PublishedOn < date && x.Genre == (Genre)genre)
                .ToArray()
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.PublishedOn)
                .Take(10)
                .Select(x => new ExportOldesBooksDto
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .ToArray();

            string result = string.Empty;

            XmlSerializerNamespaces noNamespace = new XmlSerializerNamespaces();
            noNamespace.Add("", "");

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, books, noNamespace);
                result = writer.ToString();
            }

            return result;
        }
    }
}