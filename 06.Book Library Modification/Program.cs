﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _05.Book_Library
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfBooks = int.Parse(Console.ReadLine());

            Library someLibrary = new Library();
            List<Book> listOfBooks = new List<Book>();
            Dictionary<string, DateTime> titlesReleaseAfter = new Dictionary<string, DateTime>();

            for (int i = 0; i < numberOfBooks; i++)
            {
                var booksInput = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                Book someBook = new Book();
                someBook.Title = booksInput[0];
                someBook.Author = booksInput[1];
                someBook.Publisher = booksInput[2];
                someBook.ReleaseDate = DateTime.ParseExact(booksInput[3], "dd.MM.yyyy", CultureInfo.CurrentCulture);
                someBook.IsbnNumber = long.Parse(booksInput[4]);
                someBook.Price = double.Parse(booksInput[5]);

                listOfBooks.Add(someBook);

            }

            DateTime releasedDateLimit =
                DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.CurrentCulture);

            foreach (var book in listOfBooks)
            {
                if (!titlesReleaseAfter.Keys.Contains(book.Title)&&book.ReleaseDate>releasedDateLimit)
                {
                    titlesReleaseAfter.Add(book.Title, book.ReleaseDate);
                }
             
            }

            titlesReleaseAfter.OrderBy(x => x.Value ).ThenBy(x => x.Key)
                .ToList().ForEach(x => Console.WriteLine($"{x.Key} -> {x.Value:dd.MM.yyyy}"));





        }

        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Publisher { get; set; }
            public DateTime ReleaseDate { get; set; }
            public long IsbnNumber { get; set; }
            public double Price { get; set; }


        }
        public class Library
        {
            public string Name { get; set; }
            public List<Book> ListOfBooks { get; set; }
        }
    }
}
