using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaBookLibrary.BusinessLogic
{
   public class BookLogic
    {
        private IBooksData _booksData;

        public BookLogic(IBooksData booksData)
        {
            _booksData = booksData;
        }

        public void SaveBook(Book book)
        {

            //TODO add validations
            book.Id = _booksData.GetMaxId() + 1;
            _booksData.SaveBook(book);
        }
        public void LoanBook(int bookId, string patronName, int loanPeriod)
        {
            var book = _booksData.GetBook(bookId);
            if (book.Patron != null)
            {
                // error
                return;
            }
            //validations

            var patronBooks = _booksData.GetBooks(new BooksFilter { PartonName = patronName });

            if (patronBooks.Count >= 3)
            {
                //error
                return;
            }

            book.Patron = new Patron
            {
                Name = patronName,
                LoanDate = DateTimeOffset.Now,
                LoanUntilDate = DateTimeOffset.Now.AddDays(loanPeriod)
            };

       

           _booksData.SaveBook(book);
        }
    }
}
