using Data;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace VismaBookLibrary.BusinessLogic
{
   public class BookLogic
    {
        private BooksData _booksData;

        public BookLogic(BooksData booksData)
        {
            _booksData = booksData;
        }

        public void SaveBook(Book book)
        {
            book.Id = _booksData.GetMaxId() + 1;
            _booksData.SaveBook(book);
            
        }
        
        public void DeleteBook(int bookId)
        {
            var book = _booksData.GetRequestedBook(bookId);
            
            if (book == null)
            {
                Console.WriteLine("The queried book is not part of the library catalogue. Please review your query.\r\n");
                return;
            } else if (book.Patron != null)
            {
                Console.WriteLine("This book is currently on loan. It may not be removed from the library catalogue until it is returned.\r\n");
                return;
            }

            _booksData.DeleteBook(book);
        }

        public ICollection<Book> GetBooks()
        {
            var books = _booksData.GetBooks(new BooksFilter());
            return books;
        }
        public ICollection<Book> GetBooksByAuthor(string author)
        {
            // _booksData.GetBooks(new BooksFilter());
            var books = _booksData.GetBooks(new BooksFilter { Author = author });
            return books;
        }
        public ICollection<Book> GetBooksByTitle(string title)
        {
            var books = _booksData.GetBooks(new BooksFilter { Title = title });
            return books;
        }
        public ICollection<Book> GetBooksByCategory(string category)
        {
            var books = _booksData.GetBooks(new BooksFilter { Category = category });
            return books;
        }
        public ICollection<Book> GetBooksByLanguage(string language)
        {
            var books = _booksData.GetBooks(new BooksFilter { Language = language });
            return books;
        }
        public ICollection<Book> GetBooksByISBN(string isbn)
        {
            var books = _booksData.GetBooks(new BooksFilter { ISBN = isbn });
            return books;
        }
        public ICollection<Book> GetBooksByAvailability(bool isAvailable)
        {
            var books = _booksData.GetBooks(new BooksFilter { IsAvailable = isAvailable });
            return books;
        }

        public void LoanBook(int bookId, string patronName, int requestedLoanPeriod)
        {
            var book = _booksData.GetRequestedBook(bookId);
            var patronBooksOnLoan = _booksData.GetBooks(new BooksFilter { PatronName = patronName });
            
            if (book == null) 
            {
                Console.WriteLine("Unfortunately, the requested book does not exist in the library catalogue. Please try requesting a different book.\r\n");
                return; 
            } else if (book.Patron != null) 
            {
                Console.WriteLine($"That book is currently issued to {book.Patron.Name}. Please try requesting another book.\r\n");
                return;
            } else if (patronBooksOnLoan.Count >= 3)
            {
                Console.WriteLine("The patron has exceeded the number of books allowed to take out. Please ensure no more than three books at a time are on loan for each library patron.\r\n");
                return;
            } else if (requestedLoanPeriod > book.MaxLoanPeriod)
            {
                Console.WriteLine("The book cannot be issued for longer than {0} days\r\n. Please adjust the loan period.", book.MaxLoanPeriod);
                return;
            }
            
            book.Patron = new Patron
            {
                Name = patronName,
                LoanDate = DateTimeOffset.Now,
                LoanUntilDate = DateTimeOffset.Now.AddDays(requestedLoanPeriod)
            };

            Console.WriteLine($"The book has been issued to {patronName}. It is due to be returned no later than {book.Patron.LoanDate}\r\n");
            _booksData.UpdateBookAvailability(book);
        }
        public void ReturnBook(int bookId, string patronName)
        {
            var book = _booksData.GetRequestedBook(bookId);
            string lateReturn = (book.Patron.LoanUntilDate.CompareTo(DateTimeOffset.Now).ToString());

            if (book == null)
            {
                Console.WriteLine("The patron did not borrow this book from us, so they may not return it here.");
            } else if (lateReturn == "later")
            {
                Console.WriteLine(@"                 ___====-_  _-====___");
                Console.WriteLine(@"           _--^^^#####//      \\#####^^^--_");
                Console.WriteLine(@"        _-^##########// (    ) \\##########^-_");
                Console.WriteLine(@"       -############//  |\^^/|  \\############-");
                Console.WriteLine(@"     _/############//   (@::@)   \\############\_");
                Console.WriteLine(@"    /#############((     \\//     ))#############\");
                Console.WriteLine(@"   -###############\\    (oo)    //###############-");
                Console.WriteLine(@"  -#################\\  / VV \  //#################-");
                Console.WriteLine(@" -###################\\/      \//###################-");
                Console.WriteLine(@"_#/|##########/\######(   /\   )######/\##########|\#_");
                Console.WriteLine(@"|/ |#/\#/\#/\/  \#/\##\  |  |  /##/\#/  \/\#/\#/\#| \|");
                Console.WriteLine(@"`  |/  V  V  `   V  \#\| |  | |/#/  V   '  V  V  \|  '");
                Console.WriteLine(@"   `   `  `      `   / | |  | | \   '      '  '   '");
                Console.WriteLine(@"                    (  | |  | |  )");
                Console.WriteLine(@"                   __\ | |  | | /__");
                Console.WriteLine(@"                  (vvv(VVV)(VVV)vvv)");
                Console.WriteLine("It is so nice to see them return with our book, them hoarder dragons!");
            }

            book.Patron = null;
            Console.WriteLine("The book has been returned. Thank you.\r\n");
            _booksData.UpdateBookAvailability(book);
        }
    }
}
