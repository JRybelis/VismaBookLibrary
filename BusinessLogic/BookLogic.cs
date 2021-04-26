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
        private BooksData _booksData;

        public BookLogic(BooksData booksData)
        {
            _booksData = booksData;
        }

        public void SaveBook(Book book)
        {

            //TODO add validations
            book.Id = _booksData.GetMaxId() + 1;
            _booksData.SaveBook(book);
        }
        public void LoanBook(int bookId, string patronName, int requestedLoanPeriod)
        {
            var book = _booksData.GetRequestedBook(bookId);
            var patronBooksOnLoan = _booksData.GetBooks(new BooksFilter { PatronName = patronName });
            //validations to separate class? LoanBookValidations, etc.
            if (book == null) 
            {
                Console.WriteLine("Unfortunately, the requested book does not exist in the library catalogue. Please try requesting a different book.");
                return; 
            } else if (book.Patron != null) // if the book has been loaned out to a patron
            {
                Console.WriteLine($"That book is currently issued to {book.Patron.Name}. Please try requesting another book.");
                return;
            } else if (patronBooksOnLoan.Count >= 3)
            {
                Console.WriteLine("The patron has exceeded the number of books allowed to take out. Please ensure no more than three books at a time are on loan for each library patron.");
                return;
            } else if (requestedLoanPeriod > book.MaxLoanPeriod)
            {
                Console.WriteLine("The book cannot be issued for longer than {0}                days. Please adjust the loan period.", book.MaxLoanPeriod);
                return;
            }
            
            book.Patron = new Patron
            {
                Name = patronName,
                LoanDate = DateTimeOffset.Now,
                LoanUntilDate = DateTimeOffset.Now.AddDays(requestedLoanPeriod)
            };

            Console.WriteLine($"The book has been issued to {patronName}. It is due to be returned no later than {book.Patron.LoanDate.}");
           _booksData.SaveBook(book);
        }
        public void ReturnBook(int bookId, string patronName, int requestedLoanPeriod)
        {
            var book = _booksData.GetRequestedBook(bookId);
            var patronBooksOnLoan = _booksData.GetBooks(new BooksFilter { PatronName = patronName });
            string lateReturn = (book.Patron.LoanUntilDate.CompareTo(DateTimeOffset.Now).ToString());

            if (book == null)
            {
                Console.WriteLine("You did not borrow this book from us, so you may not return it here.");
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
                Console.WriteLine("It is so nice to see you return with our book, you hoarder dragon, you!");
            }

            book.Patron = null;
            Console.WriteLine("The book has been returned. Thank you.");
            _booksData.SaveBook(book);
        }
    }
}
