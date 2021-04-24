using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using VismaBookLibrary;


namespace VismaBookLibrary.App.Controllers
{
    class BookController 
    {
        List<Book> books;
        public bool createBookRecord (Book book)
        {
            if (books.Count != 0)
            {
                book.id = books.Count;
            } else
            {
                book.id = 0;
            }
            books.Add(book);
            DataHandler bookJSON = new DataHandler();
            bookJSON.updateJSON();
            return true;
        }

        public bool deleteBookRecord (int bookId)
        {
            Book targetBook = books.Find(item => item.id == bookId); 
            if (targetBook == null)
            {
                return false; //how will the view differentiate?
            } else if (targetBook.OnLoan)
            {
                return false; //how will the view differentiate?
            } else
            {
                books.Remove(targetBook);
                DataHandler bookJSON = new DataHandler();
                bookJSON.updateJSON();
                return true;
            }
        }
    }
}
