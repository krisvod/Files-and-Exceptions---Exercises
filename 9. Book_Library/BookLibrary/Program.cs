using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace BookLibrary
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
            var AuthorSales = new Dictionary<string, double>();
            foreach (var book in lib.books)
            {
                if (!AuthorSales.ContainsKey(book.author))
                    AuthorSales.Add(book.author, book.price);
                else
                    AuthorSales[book.author] += book.price;
            }
            var SortedSales = AuthorSales
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key);
            foreach (var author in SortedSales)
            {
                File.AppendAllText("output.txt", $"{author.Key} -> {author.Value:F2}" + Environment.NewLine);
            }
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
