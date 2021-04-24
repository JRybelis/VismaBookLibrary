using System.Collections.Generic;
using System.Linq;

namespace VismaBookLibrary
{
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
