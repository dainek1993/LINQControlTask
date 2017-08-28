using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQControlTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book> {
                new Book(){ Name = "Some about LINQ", Year = 1994 },
                new Book(){ Name = "Last hero", Year = 1996 },
                new Book(){ Name = "LINQ eat my mind", Year = 2000 },
                new Book(){ Name = "Some new book", Year = 2017 },
            };

            var linqAndLeapYear = books.Where(b => b.Name.Contains("LINQ")).Where(b => DateTime.IsLeapYear(b.Year));
            foreach (var item in linqAndLeapYear)
            {
                Console.WriteLine(item.Name + " " + item.Year);
            }

            string[] someWords = { "hello", "world", "a", "the", "LINQ", "mind" };

            var count = someWords.Select(s => s.ToLower()).SelectMany(s => s).Distinct().Count();
            Console.WriteLine(count);

            int[] array = { 14, 12, 23, 13, 32, 16, 26, 31 };

            var sortedArray = array.OrderBy(i => i.ToString().First()).ThenByDescending(i => i.ToString().Last());
            foreach (var item in sortedArray)
            {
               Console.WriteLine(item);
            }

            List<AnotherBook> anotherBooks = new List<AnotherBook>{
                new AnotherBook(){ Autor = "me", Name = "Some about LINQ"},
                new AnotherBook(){ Autor = "me", Name = "Last hero"},
                new AnotherBook(){Autor = "some people", Name = "LINQ eat my mind"},
                new AnotherBook(){ Autor = "god",Name = "Some new book"},
            };

            var autorsAndBookCount = anotherBooks.GroupBy(b => b.Autor).Select(x => x.Key + " " + x.Count());

            foreach (var item in autorsAndBookCount)
            {
                Console.WriteLine(item);
            }



        }
    }
}
