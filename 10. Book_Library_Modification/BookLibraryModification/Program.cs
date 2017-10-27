using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("output.txt", "");
            string[] input = File.ReadAllLines("input.txt");
            int n = int.Parse(input[0]);
            Library lib = new Library();
            lib.books = new List<Book>();
            for (int i = 0; i < n; i++)
            {
                Book b = new Book();
                string[] inputToLib = input[i + 1]
                    .Split(' ');
                b.title = inputToLib[0];
                b.author = inputToLib[1];
                b.publisher = inputToLib[2];
                b.releaseDate = DateTime.ParseExact(inputToLib[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                b.ISBN = inputToLib[4];
                b.price = double.Parse(inputToLib[5]);
                lib.books.Add(b);
            }
            DateTime date = DateTime.ParseExact(input[input.Length - 1], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var booksAfterDate = new Dictionary<string, DateTime>();
            foreach (var book in lib.books)
            {
                if (book.releaseDate > date)
                    booksAfterDate.Add(book.title, book.releaseDate);
            }
            var SortedBooks = booksAfterDate
                .OrderBy(x => x.Value)
                .ThenBy(x => x.Key);
            foreach (var title in SortedBooks)
            {
                File.AppendAllText("output.txt", $"{title.Key} -> {title.Value.ToString("dd.MM.yyyy")}" + Environment.NewLine);
            }
        }

        class Library
        {
            public string name { get; set; }
            public List<Book> books { get; set; }
        }

        class Book
        {
            public string title { get; set; }
            public string author { get; set; }
            public string publisher { get; set; }
            public DateTime releaseDate { get; set; }
            public string ISBN { get; set; }
            public double price { get; set; }
        }
    }
}
