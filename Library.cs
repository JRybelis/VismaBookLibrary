using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaBookLibrary
{
    class Library
    {
        public List<Shelf> Shelves { get; set; }
        
        Library(List<Shelf> shelves)
        {
            Shelves = shelves;
        }
        public List<Patron> patrons { get; set; }
    }

    class Shelf
    {
        string Category { get; set; }
        List<Book> Books { get; set; }
        Shelf(string category, List<Book> books)
        {
            Category = category;
            var temp = from book in books where book.Category.ToLower() == Category.ToLower() select book;
            Books = temp.ToList();
        }
    }
}
