using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppData
    {
        private static ICollection<Book> books;
        private JsonDataHandler _dataHandler;

        public AppData(JsonDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public  ICollection<Book> Books
        {
            get
            {
                if (books == null)
                {
                    books = _dataHandler.ReadData<ICollection<Book>>("books.json") ?? new List<Book>();
                }
                return books;
            }
        }
        public void SaveBooks()
        {
            _dataHandler.SaveData("books.json", books);
        }

    }
}
