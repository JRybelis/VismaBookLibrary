using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BooksData
    {
        private AppData _appData;

        public BooksData( AppData appData)
        {
            _appData = appData;
        }
        
        public Book GetRequestedBook(int id)
        {
            var book = _appData.Books.SingleOrDefault(item => item.Id == id);
            return book;
        }
        public int GetMaxId()
        {
            var id = _appData.Books.Select(item => item.Id).DefaultIfEmpty(0).Max();
            return id;
        }

        public ICollection<Book> GetBooks(BooksFilter filter) 
        {
            var query = _appData.Books.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Author)) query = query.Where(item => item.Author.Contains(filter.Author, StringComparison.InvariantCultureIgnoreCase));
            if (!string.IsNullOrEmpty(filter.Title)) query = query.Where(item => item.Title.Contains(filter.Title, StringComparison.InvariantCultureIgnoreCase));
            if (!string.IsNullOrEmpty(filter.Category)) query = query.Where(item => item.Category.Contains(filter.Category, StringComparison.InvariantCultureIgnoreCase));
            if (!string.IsNullOrEmpty(filter.Language)) query = query.Where(item => item.Language.Contains(filter.Language, StringComparison.InvariantCultureIgnoreCase));
            if (!string.IsNullOrEmpty(filter.ISBN)) query = query.Where(item => item.ISBN.Contains(filter.ISBN, StringComparison.InvariantCultureIgnoreCase));
            if (filter.IsAvailable != null) query = filter.IsAvailable.Value
                       ? query.Where(item => item.Patron == null)
                       : query.Where(item => item.Patron != null);
            
            if (!string.IsNullOrEmpty(filter.PatronName)) query = query.Where(q => q.Patron!=null && q.Patron.Name == filter.PatronName);
            
            return query.ToList();
        }

        public void SaveBook(Book book)
        {
            _appData.Books.Add(book);
            _appData.SaveBooks();
        }
        public void UpdateBookAvailability(Book book)
        {
            _appData.SaveBooks();
        }
        public void DeleteBook(Book book)
        {
            _appData.Books.Remove(book);
            _appData.SaveBooks();
        }
    }
}
