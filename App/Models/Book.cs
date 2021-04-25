using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VismaBookLibrary
{
    class Book
    {
        List<Book> books;
        private decimal LateFee { get; set; } // per day
        public int MaxLoanPeriodDays { get; set; }
        public int BookBasket { get; set; }
        
        private string _author;
        public string Author
        {
            get => _author;
            private set 
            { 
                _author = value; 
            }
        }

        private string _title;
        public string Title
        { 
            get => _title;
            private set
            {
                _title = value;        
            } 
        }

        private string _language;
        public string Language 
        { 
            get => _language;
            private set
            {
                _language = value;
            }
        }

        private string _category;
        public string Category 
        { 
            get => _category;
            private set
            {
                _category = value;
            }
        }

        private string _iSBN;
        public string ISBN { get => _iSBN; private set
            {
                Regex regex = new Regex(@"^[0-9]{13}$");
                if (regex.IsMatch(value.ToString()))
                {
                    _iSBN = value;
                } else
                {
                    Console.WriteLine("Please ensure that the ISBN number supplied is correct. /t The current standard is 13 digits in length. To convert ISBNS of old titles to it, please use the ISBN calculator at https://www.isbn-international.org");
                }
            }

        }

        private int _publicationDate;
        public int PublicationDate
        {
            get => _publicationDate; private set
            {
                Regex regex = new Regex(@"^[0-9]{4}$");
                if (regex.IsMatch(value.ToString()))
                {
                    _publicationDate = value;
                } else
                {
                    Console.WriteLine("Please ensure that the date of publication is correct. /t Accepted format: YYYY.");
                }
            }

        }

        internal int id;

        private Patron _issuedTo;
        
        private Patron IssuedTo { get;  set; }

        private DateTime IssuedOn { get; set; }
        
        private bool _onLoan;
        public bool OnLoan 
        { 
            get => _onLoan;
            private set
            {
                _onLoan = value;
            }
        }
        public Book(string author,
                    string title,
                    string language,
                    string category,
                    string isbn,
                    int publicationDate,
                    int maxLoanPeriod = 60,
                    decimal lateFee = 0.25m)
        {
            Author = author;
            Title = title;
            Language = language;
            Category = category.Trim();
            ISBN = isbn;
            PublicationDate = publicationDate;
            MaxLoanPeriodDays = maxLoanPeriod;
            LateFee = lateFee;
        }
        // returns status of the book
        public bool LoanBook(Patron patron, int bookId, int requestedLoanPeriodDays = 7)
        {
            Book requestedBook = books.Find(item => item.id == bookId);

            if (requestedBook == null)
            {
                Console.WriteLine("Unfortunately, the requested book does not exist in the library catalogue. Please try requesting a different book.");
                return false;
            } else if (OnLoan)
            {
                Console.WriteLine($"That book is already issued to {IssuedTo.Name} {IssuedTo.Surname}.");
                return false;
            } else if (requestedLoanPeriodDays > MaxLoanPeriodDays)
            {
                Console.WriteLine("The book cannot be issued for longer than {0} days. Please adjust the loan period.", MaxLoanPeriodDays);
                return false;
            } else
            {
                OnLoan = true;
                IssuedTo = patron;
                IssuedOn = DateTime.Now; // add past date of issue? 
                Console.WriteLine($"Book has been issued to {IssuedTo.Name} {IssuedTo.Surname}.");
                return true;
            }
        }

        public bool ReturnBook(Patron patron)
        {
            if (patron.PatronID == IssuedTo.PatronID)
            {
                if (IsLate())
                {
                    int days = int.Parse((DateTime.Now - IssuedOn).TotalDays.ToString()) - MaxLoanPeriodDays;
                    decimal Penalty = ApplyPenalty(days);
                    Console.WriteLine("PLACEHOLDER FOR FUNNY MESSAGE");
                    Console.WriteLine($"The late fee of {Penalty:C} has been applied. Please pay the charges due.");
                    
                    Console.ReadLine();
                    OnLoan = false;
                    IssuedTo = null;
                    return true;
                }
                else
                {
                    OnLoan = false;
                    IssuedTo = null;
                    Console.WriteLine("The book has been returned. Thank you.");
                    return true;
                }

            } else
            {
                Console.WriteLine("You did not borrow this book, so you cannot return it.");
                return false;
            }
        }

        private decimal ApplyPenalty(int days)
        {
            //throw new NotImplementedException();
            Console.WriteLine("FUNNY MESSAGE PLACEHOLDER");
            return days * LateFee;
        }

        private bool IsLate()
        {
            if ((DateTime.Now - IssuedOn).TotalDays > MaxLoanPeriodDays)
            {
                return true;
            } else
            {
                return false;
            }
        }
        
    }
}
