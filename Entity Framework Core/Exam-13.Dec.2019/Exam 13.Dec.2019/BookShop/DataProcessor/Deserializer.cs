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
            StringBuilder sb = new StringBuilder();

            XmlSerializer serizlizer = new XmlSerializer(typeof(ImportBooksDto[]), new XmlRootAttribute("Books"));

            ImportBooksDto[] books;

            using (var reader = new StringReader(xmlString))
            {
                books = (ImportBooksDto[])serizlizer.Deserialize(reader);

            }

            foreach (var book in books)
            {
                if (!IsValid(book))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDateValid = DateTime.TryParseExact(book.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newBook = new Book()
                {
                    Name = book.Name,
                    Genre = (Genre)book.Genre,
                    Price = book.Price,
                    Pages = book.Pages,
                    PublishedOn = date
                };

                context.Books.Add(newBook);
                sb.AppendLine($"Successfully imported book {newBook.Name} for {newBook.Price}.");
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var authors = JsonConvert.DeserializeObject<ImportAuthorsDto[]>(jsonString);

            foreach (var a in authors)
            {
                if (!IsValid(a))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currEmail = context.Authors
                    .Where(x => x.Email == a.Email)
                    .FirstOrDefault();

                if (currEmail != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newAuthor = new Author()
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Phone = a.Phone,
                    Email = a.Email
                };

                context.Authors.Add(newAuthor);

                var bookcounter = 0;

                foreach (var book in a.Books)
                {
                    if (!IsValid(book))
                    {
                        continue;
                    }
                    var currBook = context.Books
                        .Where(x => x.Id == book.Id)
                        .FirstOrDefault();

                    if (currBook == null)
                    {
                        continue;
                    }

                    bookcounter++;

                    var newAuthorBooks = new AuthorBook()
                    {
                        Author = newAuthor,
                        Book = currBook

                    };

                    context.AuthorsBooks.Add(newAuthorBooks);
                }

                if (bookcounter == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                sb.AppendLine($"Successfully imported author - {newAuthor.FirstName + " " + newAuthor.LastName} with {bookcounter} books.");


                context.SaveChanges();
            }
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