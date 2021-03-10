namespace BookShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BookShop.Models.Enums;
    using Data;
    using System.Globalization;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //PROBLEM - 1
            //var command = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db, command));

            //PROBLEM - 2 
            // Console.WriteLine(GetGoldenBooks(db));

            //PROBLEM - 3
            // Console.WriteLine(GetBooksByPrice(db));

            //PROBLEM - 4
            //var year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db, year));

            //PROBLEM - 5
            //var listOfCategory = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(db,listOfCategory));

            //PROBLEM - 6
            //var endDate = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db, endDate));

            //PROBLEM - 7
            //var endOfName = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db, endOfName));

            //PROBLEM - 8
            //var partOfWord = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(db,partOfWord));

            //PROBLEM - 9
            //var partOfName = Console.ReadLine();
            //Console.WriteLine(GetBooksByAuthor(db,partOfName));

            //PROBLEM - 10
            //var titleLength = int.Parse(Console.ReadLine());
            //Console.WriteLine(CountBooks(db, titleLength));

            //PROBLEM - 11 
            //Console.WriteLine(CountCopiesByAuthor(db));

            //PROBLEM - 12
            // Console.WriteLine(GetTotalProfitByCategory(db));

            //PROBLEM - 13
            //Console.WriteLine(GetMostRecentBooks(db));
            // IncreasePrices(db);

            //PROBLEM - 15
            Console.WriteLine(RemoveBooks(db));
           
        }
        public class Author
        {
            public Author(string name, int bookCopies)
            {
                this.BookCopies = bookCopies;
                this.Name = name;
            }
            public string Name { get; set; }
            public int BookCopies { get; set; }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => new { b.Title })
                .OrderBy(b => b.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var title in books)
            {
                sb.AppendLine(title.Title);
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var editionGold = Enum.Parse<EditionType>("Gold", true);
            var books = context.Books
                .Where(b => b.EditionType == editionGold && b.Copies < 5000)
                .Select(b => new { b.BookId, b.Title })
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new { b.Title, b.Price })
                .OrderByDescending(b => b.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new { b.Title, b.BookId })
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();

            List<string> bookTitles = new List<string>();


            foreach (var cat in categories)
            {
                var currentCategories = context.Books
                    .Where(bc => bc.BookCategories
                    .Any(x => x.Category.Name.ToLower() == cat))
                    .Select(b => b.Title)
                    .ToList();

                bookTitles.AddRange(currentCategories);
            }
            bookTitles = bookTitles.OrderBy(x => x).ToList();

            return string.Join(Environment.NewLine, bookTitles);
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

            var formatDate = DateTime
                .ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < formatDate)
                .Select(b => new { b.Title, b.EditionType, b.Price, b.ReleaseDate.Value })
                .OrderByDescending(b => b.Value)
                .ToList();

            StringBuilder sb = new StringBuilder();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}"));
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                 .Where(b => b.FirstName.EndsWith(input))
                 .Select(b => new { FullName = b.FirstName + " " + b.LastName })
                 .OrderBy(b => b.FullName)
                 .ToArray();

            return string.Join(Environment.NewLine, authors.Select(a => a.FullName));


        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    AuthorsBooks = a.Books.Select(b => new
                    {
                        b.BookId,
                        b.Title
                    })
                    .OrderBy(b => b.BookId)
                    .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var a in authors)
            {
                var currAuthor = a.AuthorName;

                foreach (var book in a.AuthorsBooks)
                {
                    sb.AppendLine($"{book.Title} ({currAuthor})");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(b => b.Title).Count();

            return booksCount;
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    AuthorBooks = a.Books.Select(b => new
                    {
                        b.Copies
                    })
                   .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            List<Author> copyList = new List<Author>();

            foreach (var author in authors)
            {
                var totalCopies = 0;
                foreach (var copy in author.AuthorBooks)
                {
                    totalCopies += copy.Copies;
                }
                var newAuthor = new Author(author.AuthorName, totalCopies);
                copyList.Add(newAuthor);
            }

            copyList = copyList.OrderByDescending(x => x.BookCopies).ToList();

            foreach (var author in copyList)
            {
                sb.AppendLine($"{author.Name} - {author.BookCopies}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var books = context.Categories
                .Select(bc => new
                {
                    TotalProfit = bc.CategoryBooks.Select(c => new
                    {
                        BookProfit = c.Book.Price * c.Book.Copies
                    })
                    .Sum(x => x.BookProfit),
                    CategoryName = bc.Name,
                })
                .OrderByDescending(bc => bc.TotalProfit)
                .ThenBy(bc => bc.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in books)
            {

                sb.AppendLine($"{category.CategoryName} ${category.TotalProfit:f2}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var books = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Info = c.CategoryBooks
                    .OrderByDescending(x => x.Book.ReleaseDate)
                    .Take(3)
                    .Select(x => new
                    {
                        Title = x.Book.Title,
                        ReleaseDate = x.Book.ReleaseDate.Value.Year
                    })

                })
                .OrderBy(x => x.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var item in books)
            {
                var categoryName = item.CategoryName;
                sb.AppendLine($"--{categoryName}");

                foreach (var cat in item.Info)
                {
                    sb.AppendLine($"{cat.Title} ({cat.ReleaseDate})");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static void IncreasePrices(BookShopContext context)
        {
            var booksToUpdate = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in booksToUpdate)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            var count = books.Count();

            foreach (var book in books)
            {
                context.Remove(book);
            }
            

            context.SaveChanges();

            return count;
        }
    }

}
